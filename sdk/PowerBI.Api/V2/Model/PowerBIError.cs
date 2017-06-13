using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.PowerBI.Api.V2
{
    public class PowerBIError
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "details")]
        public IEnumerable<PowerBIExceptionDetails> Details { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}