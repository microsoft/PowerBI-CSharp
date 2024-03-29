// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Workspace info response
    /// </summary>
    public partial class WorkspaceInfoResponse
    {
        /// <summary>
        /// Initializes a new instance of the WorkspaceInfoResponse class.
        /// </summary>
        public WorkspaceInfoResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WorkspaceInfoResponse class.
        /// </summary>
        /// <param name="workspaces">The workspace info associated with this
        /// scan</param>
        /// <param name="datasourceInstances">The data source instances
        /// associated with this scan</param>
        /// <param name="misconfiguredDatasourceInstances">The data source
        /// misconfigured instances associated with this scan</param>
        public WorkspaceInfoResponse(IList<WorkspaceInfo> workspaces = default(IList<WorkspaceInfo>), IList<Datasource> datasourceInstances = default(IList<Datasource>), IList<Datasource> misconfiguredDatasourceInstances = default(IList<Datasource>))
        {
            Workspaces = workspaces;
            DatasourceInstances = datasourceInstances;
            MisconfiguredDatasourceInstances = misconfiguredDatasourceInstances;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the workspace info associated with this scan
        /// </summary>
        [JsonProperty(PropertyName = "workspaces")]
        public IList<WorkspaceInfo> Workspaces { get; set; }

        /// <summary>
        /// Gets or sets the data source instances associated with this scan
        /// </summary>
        [JsonProperty(PropertyName = "datasourceInstances")]
        public IList<Datasource> DatasourceInstances { get; set; }

        /// <summary>
        /// Gets or sets the data source misconfigured instances associated
        /// with this scan
        /// </summary>
        [JsonProperty(PropertyName = "misconfiguredDatasourceInstances")]
        public IList<Datasource> MisconfiguredDatasourceInstances { get; set; }

    }
}
