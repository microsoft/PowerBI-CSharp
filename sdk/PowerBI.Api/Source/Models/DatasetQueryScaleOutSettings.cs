// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Query scale-out settings of a dataset
    /// </summary>
    public partial class DatasetQueryScaleOutSettings
    {
        /// <summary>
        /// Initializes a new instance of the DatasetQueryScaleOutSettings
        /// class.
        /// </summary>
        public DatasetQueryScaleOutSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DatasetQueryScaleOutSettings
        /// class.
        /// </summary>
        /// <param name="autoSyncReadOnlyReplicas">Whether the dataset
        /// automatically syncs read-only replicas</param>
        /// <param name="maxReadOnlyReplicas">Maximum number of read-only
        /// replicas for the dataset (0-64, -1 for automatic number of
        /// replicas)</param>
        public DatasetQueryScaleOutSettings(bool? autoSyncReadOnlyReplicas = default(bool?), int? maxReadOnlyReplicas = default(int?))
        {
            AutoSyncReadOnlyReplicas = autoSyncReadOnlyReplicas;
            MaxReadOnlyReplicas = maxReadOnlyReplicas;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets whether the dataset automatically syncs read-only
        /// replicas
        /// </summary>
        [JsonProperty(PropertyName = "autoSyncReadOnlyReplicas")]
        public bool? AutoSyncReadOnlyReplicas { get; set; }

        /// <summary>
        /// Gets or sets maximum number of read-only replicas for the dataset
        /// (0-64, -1 for automatic number of replicas)
        /// </summary>
        [JsonProperty(PropertyName = "maxReadOnlyReplicas")]
        public int? MaxReadOnlyReplicas { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (MaxReadOnlyReplicas > 64)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "MaxReadOnlyReplicas", 64);
            }
            if (MaxReadOnlyReplicas < -1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "MaxReadOnlyReplicas", -1);
            }
        }
    }
}
