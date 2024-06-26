// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ServiceBus
{
    internal class MigrationConfigurationOperationSource : IOperationSource<MigrationConfigurationResource>
    {
        private readonly ArmClient _client;

        internal MigrationConfigurationOperationSource(ArmClient client)
        {
            _client = client;
        }

        MigrationConfigurationResource IOperationSource<MigrationConfigurationResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = MigrationConfigurationData.DeserializeMigrationConfigurationData(document.RootElement);
            return new MigrationConfigurationResource(_client, data);
        }

        async ValueTask<MigrationConfigurationResource> IOperationSource<MigrationConfigurationResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = MigrationConfigurationData.DeserializeMigrationConfigurationData(document.RootElement);
            return new MigrationConfigurationResource(_client, data);
        }
    }
}
