using Owin;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using Microsoft.PowerBI.Security;
using System.Security.Claims;

namespace PBIWebApp
{
    public partial class Startup
    {
        private string ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private string ClientSecret = ConfigurationManager.AppSettings["ida:ClientSecret"];
        private string Authority = ConfigurationManager.AppSettings["ida:AADInstance"] + "common";
        private string Resource = "https://analysis.windows.net/powerbi/api";

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions { });

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret,
                    Authority = Authority,
                    TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                    {
                        // instead of using the default validation (validating against a single issuer value, as we do in line of business apps), 
                        // we inject our own multitenant validation logic
                        ValidateIssuer = false,
                        // If the app needs access to the entire organization, then add the logic
                        // of validating the Issuer here.
                        // IssuerValidator
                    },
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        AuthorizationCodeReceived = (context) =>
                        {
                            var code = context.Code;

                            var credential = new ClientCredential(ClientId, ClientSecret);
                            var tenantID = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
                            var signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;

                            var authContext = new AuthenticationContext(string.Format("https://login.microsoftonline.com/{0}", tenantID), new TokenCache(System.Text.Encoding.Default.GetBytes(signedInUserID)));
                            var redirectUri = new Uri("http://localhost:13526/");
                            var result = authContext.AcquireTokenByAuthorizationCode(code, redirectUri, credential, Resource);

                            TokenManager.Current.WriteToken(context.AuthenticationTicket.Identity, result.AccessToken);

                            return Task.FromResult(0);
                        },
                        AuthenticationFailed = (context) =>
                        {
                            // Pass in the context back to the app
                            context.OwinContext.Response.Redirect("/");
                            context.HandleResponse(); // Suppress the exception
                            return Task.FromResult(0);
                        }
                    }
                });
        }
    }
}