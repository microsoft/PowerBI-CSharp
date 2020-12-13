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
    /// Workspace info details
    /// </summary>
    public partial class WorkspaceInfo
    {
        /// <summary>
        /// Initializes a new instance of the WorkspaceInfo class.
        /// </summary>
        public WorkspaceInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WorkspaceInfo class.
        /// </summary>
        /// <param name="id">The workspace object ID</param>
        /// <param name="name">The workspace name</param>
        /// <param name="description">The workspace description</param>
        /// <param name="type">The workspace type</param>
        /// <param name="state">The workspace state</param>
        /// <param name="dataRetrievalState">The workspace data retrieval
        /// state</param>
        /// <param name="isOnDedicatedCapacity">Whether the workspace is on
        /// dedicated capacity</param>
        /// <param name="capacityId">The workspace capacity ID</param>
        /// <param name="reports">The reports associated with this workspace.
        /// The list of properties returned varies between APIs, thus you may
        /// not see them all as part of the API response.</param>
        /// <param name="dashboards">The dashboards associated with this
        /// workspace. The list of properties returned varies between APIs,
        /// thus you may not see them all as part of the API response.</param>
        /// <param name="datasets">The datasets associated with this workspace.
        /// The list of properties returned varies between APIs, thus you may
        /// not see them all as part of the API response.</param>
        /// <param name="dataflows">The dataflows associated with this
        /// workspace. The list of properties returned varies between APIs,
        /// thus you may not see them all as part of the API response.</param>
        public WorkspaceInfo(System.Guid id, string name = default(string), string description = default(string), string type = default(string), string state = default(string), string dataRetrievalState = default(string), bool? isOnDedicatedCapacity = default(bool?), string capacityId = default(string), IList<Report> reports = default(IList<Report>), IList<Dashboard> dashboards = default(IList<Dashboard>), IList<Dataset> datasets = default(IList<Dataset>), IList<Dataflow> dataflows = default(IList<Dataflow>))
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            State = state;
            DataRetrievalState = dataRetrievalState;
            IsOnDedicatedCapacity = isOnDedicatedCapacity;
            CapacityId = capacityId;
            Reports = reports;
            Dashboards = dashboards;
            Datasets = datasets;
            Dataflows = dataflows;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the workspace object ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public System.Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the workspace name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the workspace description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the workspace type
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the workspace state
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the workspace data retrieval state
        /// </summary>
        [JsonProperty(PropertyName = "dataRetrievalState")]
        public string DataRetrievalState { get; set; }

        /// <summary>
        /// Gets or sets whether the workspace is on dedicated capacity
        /// </summary>
        [JsonProperty(PropertyName = "isOnDedicatedCapacity")]
        public bool? IsOnDedicatedCapacity { get; set; }

        /// <summary>
        /// Gets or sets the workspace capacity ID
        /// </summary>
        [JsonProperty(PropertyName = "capacityId")]
        public string CapacityId { get; set; }

        /// <summary>
        /// Gets or sets the reports associated with this workspace. The list
        /// of properties returned varies between APIs, thus you may not see
        /// them all as part of the API response.
        /// </summary>
        [JsonProperty(PropertyName = "reports")]
        public IList<Report> Reports { get; set; }

        /// <summary>
        /// Gets or sets the dashboards associated with this workspace. The
        /// list of properties returned varies between APIs, thus you may not
        /// see them all as part of the API response.
        /// </summary>
        [JsonProperty(PropertyName = "dashboards")]
        public IList<Dashboard> Dashboards { get; set; }

        /// <summary>
        /// Gets or sets the datasets associated with this workspace. The list
        /// of properties returned varies between APIs, thus you may not see
        /// them all as part of the API response.
        /// </summary>
        [JsonProperty(PropertyName = "datasets")]
        public IList<Dataset> Datasets { get; set; }

        /// <summary>
        /// Gets or sets the dataflows associated with this workspace. The list
        /// of properties returned varies between APIs, thus you may not see
        /// them all as part of the API response.
        /// </summary>
        [JsonProperty(PropertyName = "dataflows")]
        public IList<Dataflow> Dataflows { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Reports != null)
            {
                foreach (var element in Reports)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (Dashboards != null)
            {
                foreach (var element1 in Dashboards)
                {
                    if (element1 != null)
                    {
                        element1.Validate();
                    }
                }
            }
            if (Datasets != null)
            {
                foreach (var element2 in Datasets)
                {
                    if (element2 != null)
                    {
                        element2.Validate();
                    }
                }
            }
            if (Dataflows != null)
            {
                foreach (var element3 in Dataflows)
                {
                    if (element3 != null)
                    {
                        element3.Validate();
                    }
                }
            }
        }
    }
}
