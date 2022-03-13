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
    /// Power BI item metadata for a deployment pipeline stage
    /// </summary>
    public partial class PipelineStageArtifactBase
    {
        /// <summary>
        /// Initializes a new instance of the PipelineStageArtifactBase class.
        /// </summary>
        public PipelineStageArtifactBase()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PipelineStageArtifactBase class.
        /// </summary>
        /// <param name="artifactId">The Power BI item ID</param>
        /// <param name="artifactDisplayName">The Power BI item display
        /// name</param>
        /// <param name="sourceArtifactId">The ID of the Power BI item (such as
        /// a report or a dashboard) from the workspace assigned to the source
        /// stage, which will update the current Power BI item upon deployment.
        /// Applicable only when the user has at least contributor access to
        /// the source stage workspace.</param>
        /// <param name="targetArtifactId">The ID of the Power BI item (such as
        /// a report or a dashboard) from the workspace of the target stage,
        /// which will be updated by the current Power BI item upon deployment.
        /// Applicable only when the user has at least contributor access to
        /// the target stage workspace.</param>
        /// <param name="lastDeploymentTime">The last deployment date and time
        /// of the Power BI item</param>
        public PipelineStageArtifactBase(System.Guid artifactId, string artifactDisplayName = default(string), System.Guid? sourceArtifactId = default(System.Guid?), System.Guid? targetArtifactId = default(System.Guid?), System.DateTime? lastDeploymentTime = default(System.DateTime?))
        {
            ArtifactId = artifactId;
            ArtifactDisplayName = artifactDisplayName;
            SourceArtifactId = sourceArtifactId;
            TargetArtifactId = targetArtifactId;
            LastDeploymentTime = lastDeploymentTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the Power BI item ID
        /// </summary>
        [JsonProperty(PropertyName = "artifactId")]
        public System.Guid ArtifactId { get; set; }

        /// <summary>
        /// Gets or sets the Power BI item display name
        /// </summary>
        [JsonProperty(PropertyName = "artifactDisplayName")]
        public string ArtifactDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Power BI item (such as a report or a
        /// dashboard) from the workspace assigned to the source stage, which
        /// will update the current Power BI item upon deployment. Applicable
        /// only when the user has at least contributor access to the source
        /// stage workspace.
        /// </summary>
        [JsonProperty(PropertyName = "sourceArtifactId")]
        public System.Guid? SourceArtifactId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Power BI item (such as a report or a
        /// dashboard) from the workspace of the target stage, which will be
        /// updated by the current Power BI item upon deployment. Applicable
        /// only when the user has at least contributor access to the target
        /// stage workspace.
        /// </summary>
        [JsonProperty(PropertyName = "targetArtifactId")]
        public System.Guid? TargetArtifactId { get; set; }

        /// <summary>
        /// Gets or sets the last deployment date and time of the Power BI item
        /// </summary>
        [JsonProperty(PropertyName = "lastDeploymentTime")]
        public System.DateTime? LastDeploymentTime { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
