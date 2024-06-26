// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.Health.Insights.CancerProfiling
{
    /// <summary> Client options for CancerProfilingClient. </summary>
    public partial class CancerProfilingClientOptions : ClientOptions
    {
        private const ServiceVersion LatestVersion = ServiceVersion.V2023_03_01_Preview;

        /// <summary> The version of the service to use. </summary>
        public enum ServiceVersion
        {
            /// <summary> Service version "2023-03-01-preview". </summary>
            V2023_03_01_Preview = 1,
        }

        internal string Version { get; }

        /// <summary> Initializes new instance of CancerProfilingClientOptions. </summary>
        public CancerProfilingClientOptions(ServiceVersion version = LatestVersion)
        {
            Version = version switch
            {
                ServiceVersion.V2023_03_01_Preview => "2023-03-01-preview",
                _ => throw new NotSupportedException()
            };
        }
    }
}
