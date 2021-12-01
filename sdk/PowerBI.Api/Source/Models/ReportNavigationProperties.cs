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
    /// A list of navigation related properties of a report.
    /// </summary>
    public partial class ReportNavigationProperties
    {
        /// <summary>
        /// Initializes a new instance of the ReportNavigationProperties class.
        /// </summary>
        public ReportNavigationProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ReportNavigationProperties class.
        /// </summary>
        /// <param name="webUrl">The web URL of the report</param>
        /// <param name="embedUrl">The embed URL of the report</param>
        public ReportNavigationProperties(string webUrl = default(string), string embedUrl = default(string))
        {
            WebUrl = webUrl;
            EmbedUrl = embedUrl;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the web URL of the report
        /// </summary>
        [JsonProperty(PropertyName = "webUrl")]
        public string WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the embed URL of the report
        /// </summary>
        [JsonProperty(PropertyName = "embedUrl")]
        public string EmbedUrl { get; set; }

    }
}