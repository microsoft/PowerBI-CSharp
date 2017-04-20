using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.PowerBI.Core.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.PowerBI.Core.Security
{
    /// <summary>
    /// The gateway credentials used to authticate to your datasources
    /// </summary>
    public class DatasourceCredentials
    {
        /// <summary>
        /// The username used to authorize to the gateway
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The password used to authorize to the gateway
        /// </summary>
        public string Password { get; set; }
    }
}
