// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace Azure.ResourceManager.KeyVault.Models
{
    internal static partial class KeyVaultPatchModeExtensions
    {
        public static string ToSerialString(this KeyVaultPatchMode value) => value switch
        {
            KeyVaultPatchMode.Default => "default",
            KeyVaultPatchMode.Recover => "recover",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown KeyVaultPatchMode value.")
        };

        public static KeyVaultPatchMode ToKeyVaultPatchMode(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "default")) return KeyVaultPatchMode.Default;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "recover")) return KeyVaultPatchMode.Recover;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown KeyVaultPatchMode value.");
        }
    }
}
