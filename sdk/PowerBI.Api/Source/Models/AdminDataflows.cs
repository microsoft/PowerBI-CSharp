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
    /// OData response wrapper for a Power BI Admin dataflow collection
    /// </summary>
    public partial class AdminDataflows
    {
        /// <summary>
        /// Initializes a new instance of the AdminDataflows class.
        /// </summary>
        public AdminDataflows()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AdminDataflows class.
        /// </summary>
        /// <param name="odatacontext">OData context</param>
        /// <param name="value">The report collection</param>
        public AdminDataflows(string odatacontext = default(string), IList<AdminDataflow> value = default(IList<AdminDataflow>))
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
        /// Gets or sets the report collection
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public IList<AdminDataflow> Value { get; set; }

    }
}
