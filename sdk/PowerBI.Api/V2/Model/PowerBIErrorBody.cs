using Newtonsoft.Json;

namespace Microsoft.PowerBI.Api.V2
{
    public class PowerBIErrorBody
    {
        [JsonProperty(PropertyName = "error")]
        public PowerBIError Error { get; set; }
    }
}