using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHost.Models
{
    public class WorkspaceCollection
    {
        [JsonProperty(PropertyName = "objectId")]
        Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        string Name { get; set; }
    }
}
