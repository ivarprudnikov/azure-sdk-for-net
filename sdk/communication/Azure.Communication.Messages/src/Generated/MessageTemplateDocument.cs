// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Communication.Messages
{
    /// <summary> The message template's document value information. </summary>
    public partial class MessageTemplateDocument : MessageTemplateValue
    {
        /// <summary> Initializes a new instance of <see cref="MessageTemplateDocument"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="uri"/> is null. </exception>
        public MessageTemplateDocument(string name, Uri uri) : base(name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            Kind = "document";
            Uri = uri;
        }

        /// <summary> Initializes a new instance of <see cref="MessageTemplateDocument"/>. </summary>
        /// <param name="name"> Template binding reference name. </param>
        /// <param name="kind"> The type discriminator describing a template parameter type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="uri"> The (public) URL of the media. </param>
        /// <param name="caption"> The [optional] caption of the media object. </param>
        /// <param name="fileName"> The [optional] filename of the media file. </param>
        internal MessageTemplateDocument(string name, string kind, IDictionary<string, BinaryData> serializedAdditionalRawData, Uri uri, string caption, string fileName) : base(name, kind, serializedAdditionalRawData)
        {
            Uri = uri;
            Caption = caption;
            FileName = fileName;
        }

        /// <summary> Initializes a new instance of <see cref="MessageTemplateDocument"/> for deserialization. </summary>
        internal MessageTemplateDocument()
        {
        }

        /// <summary> The (public) URL of the media. </summary>
        public Uri Uri { get; }
        /// <summary> The [optional] caption of the media object. </summary>
        public string Caption { get; set; }
        /// <summary> The [optional] filename of the media file. </summary>
        public string FileName { get; set; }
    }
}
