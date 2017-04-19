// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.PowerBI.Api.V1.Models
{
    using Microsoft.PowerBI;
    using Microsoft.PowerBI.Api;
    using Microsoft.PowerBI.Api.V1;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A dataset odata list wrapper
    /// </summary>
    public partial class ODataResponseListDataset
    {
        /// <summary>
        /// Initializes a new instance of the ODataResponseListDataset class.
        /// </summary>
        public ODataResponseListDataset()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ODataResponseListDataset class.
        /// </summary>
        /// <param name="value">The datasets</param>
        public ODataResponseListDataset(string odatacontext = default(string), IList<Dataset> value = default(IList<Dataset>))
        {
            Odatacontext = odatacontext;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "odata.context")]
        public string Odatacontext { get; set; }

        /// <summary>
        /// Gets or sets the datasets
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<Dataset> Value { get; set; }

    }
}
