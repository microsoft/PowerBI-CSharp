using Newtonsoft.Json;

namespace Microsoft.PowerBI.Api.V2
{
    public class PowerBIExceptionDetails
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}