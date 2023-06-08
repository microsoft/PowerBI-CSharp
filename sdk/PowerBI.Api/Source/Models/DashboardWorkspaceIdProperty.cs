// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class DashboardWorkspaceIdProperty
    {
        /// <summary>
        /// Initializes a new instance of the DashboardWorkspaceIdProperty
        /// class.
        /// </summary>
        public DashboardWorkspaceIdProperty()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DashboardWorkspaceIdProperty
        /// class.
        /// </summary>
        /// <param name="workspaceId">The workspace ID (GUID) of the dashboard.
        /// This property will be returned only in
        /// GetDashboardsAsAdmin.</param>
        public DashboardWorkspaceIdProperty(System.Guid? workspaceId = default(System.Guid?))
        {
            WorkspaceId = workspaceId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the workspace ID (GUID) of the dashboard. This
        /// property will be returned only in GetDashboardsAsAdmin.
        /// </summary>
        [JsonProperty(PropertyName = "workspaceId")]
        public System.Guid? WorkspaceId { get; set; }

    }
}
