// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Batch.Protocol.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The set of changes to be made to a task.
    /// </summary>
    public partial class TaskUpdateParameter
    {
        /// <summary>
        /// Initializes a new instance of the TaskUpdateParameter class.
        /// </summary>
        public TaskUpdateParameter()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the TaskUpdateParameter class.
        /// </summary>
        /// <param name="constraints">Constraints that apply to this
        /// task.</param>
        public TaskUpdateParameter(TaskConstraints constraints = default(TaskConstraints))
        {
            Constraints = constraints;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets constraints that apply to this task.
        /// </summary>
        /// <remarks>
        /// If omitted, the task is given the default constraints. For
        /// multi-instance tasks, updating the retention time applies only to
        /// the primary task and not subtasks.
        /// </remarks>
        [JsonProperty(PropertyName = "constraints")]
        public TaskConstraints Constraints { get; set; }

    }
}
