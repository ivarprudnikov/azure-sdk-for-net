// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.StorageCache.Models
{
    /// <summary> AML file system client information. </summary>
    public partial class AmlFileSystemClientInfo
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

        /// <summary> Initializes a new instance of <see cref="AmlFileSystemClientInfo"/>. </summary>
        internal AmlFileSystemClientInfo()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AmlFileSystemClientInfo"/>. </summary>
        /// <param name="mgsAddress"> The IPv4 address used by clients to mount the AML file system's Lustre Management Service (MGS). </param>
        /// <param name="mountCommand"> Recommended command to mount the AML file system. </param>
        /// <param name="lustreVersion"> The version of Lustre running in the AML file system. </param>
        /// <param name="containerStorageInterface"> Container Storage Interface information for the AML file system. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AmlFileSystemClientInfo(string mgsAddress, string mountCommand, string lustreVersion, AmlFileSystemContainerStorageInterface containerStorageInterface, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            MgsAddress = mgsAddress;
            MountCommand = mountCommand;
            LustreVersion = lustreVersion;
            ContainerStorageInterface = containerStorageInterface;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The IPv4 address used by clients to mount the AML file system's Lustre Management Service (MGS). </summary>
        public string MgsAddress { get; }
        /// <summary> Recommended command to mount the AML file system. </summary>
        public string MountCommand { get; }
        /// <summary> The version of Lustre running in the AML file system. </summary>
        public string LustreVersion { get; }
        /// <summary> Container Storage Interface information for the AML file system. </summary>
        public AmlFileSystemContainerStorageInterface ContainerStorageInterface { get; }
    }
}
