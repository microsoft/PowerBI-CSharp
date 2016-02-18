// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.PowerBI.Api.Beta.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// </summary>
    public partial class Column
    {
        /// <summary>
        /// Initializes a new instance of the Column class.
        /// </summary>
        public Column() { }

        /// <summary>
        /// Initializes a new instance of the Column class.
        /// </summary>
        public Column(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dataType")]
        public string DataType { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (DataType == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DataType");
            }
            if (this.Name != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Name, "^[\\x09\\x0A\\x0D\\x20-\\uD7FF\\uE000-\\uFFFD\\u10000-\\u10FFFF]+$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Name", "^[\\x09\\x0A\\x0D\\x20-\\uD7FF\\uE000-\\uFFFD\\u10000-\\u10FFFF]+$");
                }
            }
        }
    }
}