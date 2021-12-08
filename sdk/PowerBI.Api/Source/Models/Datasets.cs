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
    /// A dataset OData list wrapper
    /// </summary>
    public partial class Datasets
    {
        /// <summary>
        /// Initializes a new instance of the Datasets class.
        /// </summary>
        public Datasets()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Datasets class.
        /// </summary>
        /// <param name="odatacontext">OData context</param>
        /// <param name="value">The datasets</param>
        public Datasets(string odatacontext = default(string), IList<Dataset> value = default(IList<Dataset>))
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
        /// Gets or sets oData context
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
