// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.RecoveryServicesSiteRecovery.Models
{
    /// <summary> Details of the appliance resource. </summary>
    public partial class DataStoreUtilizationDetails
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DataStoreUtilizationDetails"/>. </summary>
        internal DataStoreUtilizationDetails()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DataStoreUtilizationDetails"/>. </summary>
        /// <param name="totalSnapshotsSupported"> The total count of snapshots supported by the datastore. </param>
        /// <param name="totalSnapshotsCreated"> The total snapshots created for server migration in the datastore. </param>
        /// <param name="dataStoreName"> The datastore name. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DataStoreUtilizationDetails(long? totalSnapshotsSupported, long? totalSnapshotsCreated, string dataStoreName, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TotalSnapshotsSupported = totalSnapshotsSupported;
            TotalSnapshotsCreated = totalSnapshotsCreated;
            DataStoreName = dataStoreName;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The total count of snapshots supported by the datastore. </summary>
        public long? TotalSnapshotsSupported { get; }
        /// <summary> The total snapshots created for server migration in the datastore. </summary>
        public long? TotalSnapshotsCreated { get; }
        /// <summary> The datastore name. </summary>
        public string DataStoreName { get; }
    }
}
