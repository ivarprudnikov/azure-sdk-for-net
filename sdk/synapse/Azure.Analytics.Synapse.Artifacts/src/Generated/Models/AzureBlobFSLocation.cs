// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Analytics.Synapse.Artifacts.Models
{
    /// <summary> The location of azure blobFS dataset. </summary>
    public partial class AzureBlobFSLocation : DatasetLocation
    {
        /// <summary> Initializes a new instance of <see cref="AzureBlobFSLocation"/>. </summary>
        public AzureBlobFSLocation()
        {
            Type = "AzureBlobFSLocation";
        }

        /// <summary> Initializes a new instance of <see cref="AzureBlobFSLocation"/>. </summary>
        /// <param name="type"> Type of dataset storage location. </param>
        /// <param name="folderPath"> Specify the folder path of dataset. Type: string (or Expression with resultType string). </param>
        /// <param name="fileName"> Specify the file name of dataset. Type: string (or Expression with resultType string). </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <param name="fileSystem"> Specify the fileSystem of azure blobFS. Type: string (or Expression with resultType string). </param>
        internal AzureBlobFSLocation(string type, object folderPath, object fileName, IDictionary<string, object> additionalProperties, object fileSystem) : base(type, folderPath, fileName, additionalProperties)
        {
            FileSystem = fileSystem;
            Type = type ?? "AzureBlobFSLocation";
        }

        /// <summary> Specify the fileSystem of azure blobFS. Type: string (or Expression with resultType string). </summary>
        public object FileSystem { get; set; }
    }
}
