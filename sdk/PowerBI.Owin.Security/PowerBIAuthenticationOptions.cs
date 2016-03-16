using System;

namespace Microsoft.PowerBI.Owin.Security
{
    /// <summary>
    /// The Power BI Authentication options
    /// </summary>
    public class PowerBIAuthenticationOptions
    {
        private const string DefaultResource = "https://analysis.windows.net/powerbi/api";
        private const string DefaultAuthority = "https://login.microsoftonline.com/common";

        /// <summary>
        /// Creates a new instance of the Power BI Authentication options
        /// </summary>
        public PowerBIAuthenticationOptions()
        {
            this.Resource = DefaultResource;
            this.Authority = DefaultAuthority;
            this.ValidateIssuer = false;
        }

        /// <summary>
        /// The client Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The client secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The Authority to authenticate against.  This is typically https://login.microsoftonline.com/common
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// The resource to access.  This is typically https://analysis.windows.net/powerbi/api
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// The url to redirect to upon a successfull authentiation attempt
        /// </summary>
        public Uri SuccessRedirectUri { get; set; }

        /// <summary>
        /// The url to redirect to upon a failed authentication attempt
        /// </summary>
        public Uri ErrorRedirectUri { get; set; }

        /// <summary>
        /// The expected token issuer
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Whether or not to strictly validate the issuer before issues a token
        /// </summary>
        public bool ValidateIssuer { get; set; }
    }
}
