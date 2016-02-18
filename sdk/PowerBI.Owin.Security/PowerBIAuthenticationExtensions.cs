using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.PowerBI.Owin.Security;
using Microsoft.PowerBI.Security;
using System;
using System.IdentityModel.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Owin
{
    public static class PowerBIAuthenticationExtensions
    {
        public static IAppBuilder UsePowerBIAuthentication(this IAppBuilder app, PowerBIAuthenticationOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            ValidateOptions(options);

            var openIdAuthOptions = new OpenIdConnectAuthenticationOptions
            {
                ClientId = options.ClientId,
                ClientSecret = options.ClientSecret,
                Authority = options.Authority,
                TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = options.Issuer,
                    ValidateIssuer = options.ValidateIssuer
                },
                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    AuthorizationCodeReceived = (context) =>
                    {
                        OnAuthorizationCodeReceived(context, options);
                        return Task.FromResult(0);
                    },
                    AuthenticationFailed = (context) =>
                    {
                        var redirectUri = options.ErrorRedirectUri ?? new Uri("/", UriKind.Relative);
                        context.OwinContext.Response.Redirect(redirectUri.ToString());
                        context.HandleResponse();
                        return Task.FromResult(0);
                    }
                }
            };

            app.UseOpenIdConnectAuthentication(openIdAuthOptions);
            ConfigureTokenManager();

            return app;
        }

        public static IAppBuilder UsePowerBIAuthentication(this IAppBuilder app, Action<PowerBIAuthenticationOptions> setOptions)
        {
            if (setOptions == null)
            {
                throw new ArgumentNullException("setOptions");
            }

            var options = new PowerBIAuthenticationOptions();
            setOptions(options);

            return UsePowerBIAuthentication(app, options);
        }

        private static void OnAuthorizationCodeReceived(AuthorizationCodeReceivedNotification context, PowerBIAuthenticationOptions options)
        {
            var code = context.Code;

            var credential = new ClientCredential(options.ClientId, options.ClientSecret);
            var tenantID = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            var signedInUserID = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var authContext = new AuthenticationContext(string.Format("https://login.microsoftonline.com/{0}", tenantID), new TokenCache(Encoding.Default.GetBytes(signedInUserID)));
            var result = authContext.AcquireTokenByAuthorizationCode(code, options.SuccessRedirectUri, credential, options.Resource);

            TokenManager.Current.WriteToken(context.AuthenticationTicket.Identity, result.AccessToken);
        }

        private static void ValidateOptions(PowerBIAuthenticationOptions options)
        {
            if (string.IsNullOrEmpty(options.ClientId))
            {
                throw new InvalidOperationException("ClientID is not set");
            }

            if (string.IsNullOrEmpty(options.ClientSecret))
            {
                throw new InvalidOperationException("ClientSecret is not set");
            }

            if (options.ValidateIssuer && string.IsNullOrWhiteSpace(options.Issuer))
            {
                throw new InvalidOperationException("Issuer is not set");
            }

            if (string.IsNullOrWhiteSpace(options.Authority))
            {
                throw new InvalidOperationException("Authority is not set");
            }

            if (string.IsNullOrWhiteSpace(options.Resource))
            {
                throw new InvalidOperationException("Resource is not set");
            }

            if (options.SuccessRedirectUri == null)
            {
                throw new InvalidOperationException("SuccessRedirectUri is not set");
            }
        }

        private static void ConfigureTokenManager()
        {
            const string cookieKey = "powerbi-token";

            TokenManager.Current.SetTokenReader(identity =>
            {
                var powerBITokenCookie = HttpContext.Current.Request.Cookies.Get(cookieKey);
                if (powerBITokenCookie == null)
                {
                    return null;
                }

                return powerBITokenCookie.Value;
            });

            TokenManager.Current.SetTokenWriter((identity, accessToken) =>
            {
                var powerBITokenCookie = new HttpCookie(cookieKey, accessToken);
                HttpContext.Current.Response.Cookies.Add(powerBITokenCookie);
            });
        }
    }
}
