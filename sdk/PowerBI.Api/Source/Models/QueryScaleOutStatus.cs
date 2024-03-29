// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.Models
{

    /// <summary>
    /// Defines values for QueryScaleOutStatus.
    /// </summary>
    public static class QueryScaleOutStatus
    {
        /// <summary>
        /// Query scale-out is enabled
        /// </summary>
        public const string Enabled = "Enabled";
        /// <summary>
        /// Query scale-out tenant setting is disabled
        /// </summary>
        public const string TenantSettingDisabled = "TenantSettingDisabled";
        /// <summary>
        /// Query scale-out is not supported for dataset's storage mode
        /// </summary>
        public const string StorageModeNotSupported = "StorageModeNotSupported";
        /// <summary>
        /// Query scale-out max read-only replicas is set to 0
        /// </summary>
        public const string ReadOnlyReplicasDisabled = "ReadOnlyReplicasDisabled";
    }
}
