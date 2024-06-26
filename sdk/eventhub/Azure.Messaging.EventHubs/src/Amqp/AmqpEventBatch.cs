﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   A set of events with known size constraints, based on messages to be sent
    ///   using an AMQP-based transport.
    /// </summary>
    ///
    internal class AmqpEventBatch : TransportEventBatch
    {
        /// <summary>The amount of bytes to reserve as overhead for a small message.</summary>
        private const byte OverheadBytesSmallMessage = 5;

        /// <summary>The amount of bytes to reserve as overhead for a large message.</summary>
        private const byte OverheadBytesLargeMessage = 8;

        /// <summary>The maximum number of bytes that a message may be to be considered small.</summary>
        private const byte MaximumBytesSmallMessage = 255;

        /// <summary>The size of the batch, in bytes, to reserve for the AMQP message overhead.</summary>
        private readonly long _reservedOverheadBytes;

        /// <summary>The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.</summary>
        private readonly AmqpMessageConverter _messageConverter;

        /// <summary>The set of options to apply to the batch.</summary>
        private readonly CreateBatchOptions _options;

        /// <summary>The set of events that have been added to the batch, in their <see cref="AmqpMessage" /> serialized format.</summary>
        private readonly List<AmqpMessage> _batchMessages = new();

        /// <summary>The first sequence number of the batch; if not sequenced, <c>null</c>.</summary>
        private int? _startingSequenceNumber;

        /// <summary>The size of the batch, in bytes, as it will be sent via the AMQP transport.</summary>
        private long _sizeBytes;

        /// <summary>A flag that indicates whether or not the instance has been disposed.</summary>
        private volatile bool _disposed;

        /// <summary>
        ///   The maximum size allowed for the batch, in bytes.  This includes the events in the batch as
        ///   well as any overhead for the batch itself when sent to the Event Hubs service.
        /// </summary>
        ///
        public override long MaximumSizeInBytes { get; }

        /// <summary>
        ///   The flags specifying the set of special transport features that have been opted-into.
        /// </summary>
        ///
        public override TransportProducerFeatures ActiveFeatures { get; }

        /// <summary>
        ///   The size of the batch, in bytes, as it will be sent to the Event Hubs
        ///   service.
        /// </summary>
        ///
        public override long SizeInBytes => _sizeBytes;

        /// <summary>
        ///   The count of events contained in the batch.
        /// </summary>
        ///
        public override int Count => _batchMessages.Count;

        /// <summary>
        ///   The first sequence number of the batch; if not sequenced, <c>null</c>.
        /// </summary>
        ///
        public override int? StartingSequenceNumber => _startingSequenceNumber;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpEventBatch"/> class.
        /// </summary>
        ///
        /// <param name="messageConverter">The converter to use for translating <see cref="EventData" /> into the corresponding AMQP message.</param>
        /// <param name="options">The set of options to apply to the batch.</param>
        /// <param name="activeFeatures">The flags specifying the set of special transport features have been opted-into.</param>
        ///
        public AmqpEventBatch(AmqpMessageConverter messageConverter,
                              CreateBatchOptions options,
                              TransportProducerFeatures activeFeatures)
        {
            Argument.AssertNotNull(messageConverter, nameof(messageConverter));
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotNull(options.MaximumSizeInBytes, nameof(options.MaximumSizeInBytes));

            _messageConverter = messageConverter;
            _options = options;

            MaximumSizeInBytes = options.MaximumSizeInBytes.Value;
            ActiveFeatures = activeFeatures;

            // Initialize the size by reserving space for the batch envelope.  At this point, the
            // set of batch events is empty, so the message returned will only represent the envelope.

            using AmqpMessage envelope = messageConverter.CreateBatchFromMessages(Array.Empty<AmqpMessage>(), options.PartitionKey);

            _reservedOverheadBytes = envelope.SerializedMessageSize;
            _sizeBytes = _reservedOverheadBytes;
        }

        /// <summary>
        ///   Attempts to add an event to the batch, ensuring that the size
        ///   of the batch does not exceed its maximum.
        /// </summary>
        ///
        /// <param name="eventData">The event to attempt to add to the batch.</param>
        ///
        /// <returns><c>true</c> if the event was added; otherwise, <c>false</c>.</returns>
        ///
        public override bool TryAdd(EventData eventData)
        {
            Argument.AssertNotNull(eventData, nameof(eventData));
            Argument.AssertNotDisposed(_disposed, nameof(EventDataBatch));

            // Reserve space for producer-owned fields that correspond to special
            // features, if enabled.

            if ((ActiveFeatures & TransportProducerFeatures.IdempotentPublishing) != 0)
            {
                eventData.PendingPublishSequenceNumber = int.MaxValue;
                eventData.PendingProducerGroupId = long.MaxValue;
                eventData.PendingProducerOwnerLevel = short.MaxValue;
            }

            try
            {
                // Calculate the size for the event, based on the AMQP message size and accounting for a
                // bit of reserved overhead size.

                var message = _messageConverter.CreateMessageFromEvent(eventData, _options.PartitionKey);

                var size = _sizeBytes + message.SerializedMessageSize
                    + (message.SerializedMessageSize <= MaximumBytesSmallMessage
                        ? OverheadBytesSmallMessage
                        : OverheadBytesLargeMessage);

                if (size > MaximumSizeInBytes)
                {
                    message.Dispose();
                    return false;
                }

                _sizeBytes = size;
                _batchMessages.Add(message);

                return true;
            }
            finally
            {
                eventData.ClearPublishingState();
            }
        }

        /// <summary>
        ///   Clears the batch, removing all events and resetting the
        ///   available size.
        /// </summary>
        ///
        public override void Clear()
        {
            foreach (var message in _batchMessages)
            {
                message.Dispose();
            }

            _batchMessages.Clear();
            _sizeBytes = _reservedOverheadBytes;
        }

        /// <summary>
        ///   Represents the batch as a set of the AMQP-specific representations of an event.
        /// </summary>
        ///
        /// <typeparam name="T">The transport-specific event representation being requested.</typeparam>
        ///
        /// <returns>The set of events as an enumerable of the requested type.</returns>
        ///
        public override IReadOnlyCollection<T> AsReadOnlyCollection<T>()
        {
            if (typeof(T) != typeof(AmqpMessage))
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.UnsupportedTransportEventType, typeof(T).Name));
            }

            return _batchMessages as IReadOnlyCollection<T>;
        }

        /// <summary>
        ///   Assigns message sequence numbers and publisher metadata to the batch in
        ///   order to prepare it to be sent when certain features, such as idempotent retries,
        ///   are active.
        /// </summary>
        ///
        /// <param name="lastSequenceNumber">The sequence number assigned to the event that was most recently published to the associated partition successfully.</param>
        /// <param name="producerGroupId">The identifier of the producer group for which publishing is being performed.</param>
        /// <param name="ownerLevel">TThe owner level for which publishing is being performed.</param>
        ///
        /// <returns>The last sequence number applied to the batch.</returns>
        ///
        public override int ApplyBatchSequencing(int lastSequenceNumber,
                                                 long? producerGroupId,
                                                 short? ownerLevel)
        {
            if (_batchMessages.Count == 0)
            {
                return lastSequenceNumber;
            }

            _startingSequenceNumber = NextSequence(lastSequenceNumber);

            foreach (var message in _batchMessages)
            {
                lastSequenceNumber = NextSequence(lastSequenceNumber);
                _messageConverter.ApplyPublisherPropertiesToAmqpMessage(message, lastSequenceNumber, producerGroupId, ownerLevel);
            }

            return lastSequenceNumber;
        }

        /// <summary>
        ///   Resets the batch to remove sequencing information and publisher metadata assigned
        ///    by <see cref="ApplyBatchSequencing" />.
        /// </summary>
        ///
        public override void ResetBatchSequencing()
        {
            _startingSequenceNumber = null;

            foreach (var message in _batchMessages)
            {
                _messageConverter.RemovePublishingPropertiesFromAmqpMessage(message);
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="AmqpEventBatch" />.
        /// </summary>
        ///
        public override void Dispose()
        {
            _disposed = true;
            Clear();
        }

        /// <summary>
        ///   Calculates the next sequence number based on the current sequence number.
        /// </summary>
        ///
        /// <param name="currentSequence">The current sequence number to consider.</param>
        ///
        /// <returns>The next sequence number, in proper order.</returns>
        ///
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int NextSequence(int currentSequence)
        {
            if (unchecked(++currentSequence) < 0)
            {
                currentSequence = 0;
            }

            return currentSequence;
        }
    }
}
