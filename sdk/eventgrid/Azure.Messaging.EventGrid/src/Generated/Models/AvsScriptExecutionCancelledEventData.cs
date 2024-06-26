// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.AVS.ScriptExecutionCancelled event. </summary>
    public partial class AvsScriptExecutionCancelledEventData : AvsScriptExecutionEventData
    {
        /// <summary> Initializes a new instance of <see cref="AvsScriptExecutionCancelledEventData"/>. </summary>
        internal AvsScriptExecutionCancelledEventData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AvsScriptExecutionCancelledEventData"/>. </summary>
        /// <param name="operationId"> Id of the operation that caused this event. </param>
        /// <param name="cmdletId"> Cmdlet referenced in the execution that caused this event. </param>
        /// <param name="output"> Stdout outputs from the execution, if any. </param>
        internal AvsScriptExecutionCancelledEventData(string operationId, string cmdletId, IReadOnlyList<string> output) : base(operationId, cmdletId, output)
        {
        }
    }
}
