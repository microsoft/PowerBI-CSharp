using Owin;
using System.Configuration;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;

namespace Microsoft.PowerBI.AspNet.Mvc
{
    public partial class Startup
    {
        public void ConfigurePowerBI(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            app.UsePowerBIAuthentication((options) =>
            {
                options.ClientId = ConfigurationManager.AppSettings["powerbi:ClientId"];
                options.ClientSecret = ConfigurationManager.AppSettings["powerbi:ClientSecret"];
                options.Issuer = ConfigurationManager.AppSettings["powerbi:Issuer"];
                options.SuccessRedirectUri = new System.Uri(ConfigurationManager.AppSettings["powerbi:RedirectUri"]);
            });
        }
    }
}