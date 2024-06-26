// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.Analytics.Defender.Easm
{
    /// <summary> A request body used to retrieve an asset report snapshot. </summary>
    public partial class ReportAssetSnapshotPayload
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

        /// <summary> Initializes a new instance of <see cref="ReportAssetSnapshotPayload"/>. </summary>
        public ReportAssetSnapshotPayload()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ReportAssetSnapshotPayload"/>. </summary>
        /// <param name="metric"> The metric to retrieve a snapshot for. </param>
        /// <param name="labelName"> The name of the label to retrieve a snapshot for. </param>
        /// <param name="size"> The number of assets per page. </param>
        /// <param name="page"> The page to retrieve. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ReportAssetSnapshotPayload(string metric, string labelName, int? size, int? page, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Metric = metric;
            LabelName = labelName;
            Size = size;
            Page = page;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The metric to retrieve a snapshot for. </summary>
        public string Metric { get; set; }
        /// <summary> The name of the label to retrieve a snapshot for. </summary>
        public string LabelName { get; set; }
        /// <summary> The number of assets per page. </summary>
        public int? Size { get; set; }
        /// <summary> The page to retrieve. </summary>
        public int? Page { get; set; }
    }
}
