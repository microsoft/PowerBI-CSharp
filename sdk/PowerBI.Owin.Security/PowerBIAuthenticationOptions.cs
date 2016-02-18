using System;

namespace Microsoft.PowerBI.Owin.Security
{
    public class PowerBIAuthenticationOptions
    {
        private const string DefaultResource = "https://analysis.windows.net/powerbi/api";
        private const string DefaultAuthority = "https://login.microsoftonline.com/common";

        public PowerBIAuthenticationOptions()
        {
            this.Resource = DefaultResource;
            this.Authority = DefaultAuthority;
            this.ValidateIssuer = false;
        }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Authority { get; set; }

        public string Resource { get; set; }

        public Uri SuccessRedirectUri { get; set; }

        public Uri ErrorRedirectUri { get; set; }

        public string Issuer { get; set; }

        public bool ValidateIssuer { get; set; }
    }
}
