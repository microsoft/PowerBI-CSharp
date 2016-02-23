using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHost.Models
{
    public class WorkspaceCollectionKeys
    {
        [JsonProperty(PropertyName = "key1")]
        public string Key1 { get; set; }

        [JsonProperty(PropertyName = "key2")]
        public string Key2 { get; set; }
    }
}
