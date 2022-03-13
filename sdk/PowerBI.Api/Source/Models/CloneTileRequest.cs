// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A Power BI request to clone a tile
    /// </summary>
    public partial class CloneTileRequest
    {
        /// <summary>
        /// Initializes a new instance of the CloneTileRequest class.
        /// </summary>
        public CloneTileRequest()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CloneTileRequest class.
        /// </summary>
        /// <param name="targetDashboardId">The target dashboard ID</param>
        /// <param name="targetWorkspaceId">(Optional) A parameter for
        /// specifying a target workspace ID. An empty GUID
        /// (`00000000-0000-0000-0000-000000000000`) indicates **My
        /// workspace**. If this parameter isn't provided, the tile will be
        /// cloned within the same workspace as the source tile.</param>
        /// <param name="targetReportId">(Optional) A parameter for specifying
        /// a target report ID. When cloning a tile linked to a report, pass
        /// the target report ID to rebind the new tile to a different
        /// report.</param>
        /// <param name="targetModelId">(Optional) A parameter for specifying a
        /// target model ID. When cloning a tile linked to a dataset, pass the
        /// target model ID to rebind the new tile to a different
        /// dataset.</param>
        /// <param name="positionConflictAction">(Optional) A parameter for
        /// specifying an action in case of a position conflict. If there's a
        /// conflict and this parameter isn't provided, then the default value
        /// `Tail` will be applied. If there's no conflict, then the cloned
        /// tile will have the same position as in the source. Possible values
        /// include: 'Tail', 'Abort'</param>
        public CloneTileRequest(System.Guid targetDashboardId, System.Guid? targetWorkspaceId = default(System.Guid?), System.Guid? targetReportId = default(System.Guid?), string targetModelId = default(string), PositionConflictAction? positionConflictAction = default(PositionConflictAction?))
        {
            TargetDashboardId = targetDashboardId;
            TargetWorkspaceId = targetWorkspaceId;
            TargetReportId = targetReportId;
            TargetModelId = targetModelId;
            PositionConflictAction = positionConflictAction;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the target dashboard ID
        /// </summary>
        [JsonProperty(PropertyName = "targetDashboardId")]
        public System.Guid TargetDashboardId { get; set; }

        /// <summary>
        /// Gets or sets (Optional) A parameter for specifying a target
        /// workspace ID. An empty GUID
        /// (`00000000-0000-0000-0000-000000000000`) indicates **My
        /// workspace**. If this parameter isn't provided, the tile will be
        /// cloned within the same workspace as the source tile.
        /// </summary>
        [JsonProperty(PropertyName = "targetWorkspaceId")]
        public System.Guid? TargetWorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets (Optional) A parameter for specifying a target report
        /// ID. When cloning a tile linked to a report, pass the target report
        /// ID to rebind the new tile to a different report.
        /// </summary>
        [JsonProperty(PropertyName = "targetReportId")]
        public System.Guid? TargetReportId { get; set; }

        /// <summary>
        /// Gets or sets (Optional) A parameter for specifying a target model
        /// ID. When cloning a tile linked to a dataset, pass the target model
        /// ID to rebind the new tile to a different dataset.
        /// </summary>
        [JsonProperty(PropertyName = "targetModelId")]
        public string TargetModelId { get; set; }

        /// <summary>
        /// Gets or sets (Optional) A parameter for specifying an action in
        /// case of a position conflict. If there's a conflict and this
        /// parameter isn't provided, then the default value `Tail` will be
        /// applied. If there's no conflict, then the cloned tile will have the
        /// same position as in the source. Possible values include: 'Tail',
        /// 'Abort'
        /// </summary>
        [JsonProperty(PropertyName = "positionConflictAction")]
        public PositionConflictAction? PositionConflictAction { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}
