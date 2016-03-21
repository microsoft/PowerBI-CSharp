using Newtonsoft.Json;

namespace ProvisionSample.Models
{
    public class BillingUsage
    {
        [JsonProperty(PropertyName = "renders")]
        public int Renders { get; set; }
    }
}
