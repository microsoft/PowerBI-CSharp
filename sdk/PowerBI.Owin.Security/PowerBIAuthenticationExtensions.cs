using System;
using System.IdentityModel.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.PowerBI.Owin.Security;
using Microsoft.PowerBI.Security;

namespace Owin
{
    /// <summary>
    /// Power BI Authentication Extensions
    /// </summary>
    public static class PowerBIAuthenticationExtensions
    {
        /// <summary>
        /// Configures the application to use Azure AD with Power BI
        /// </summary>
        /// <param name="app">The OWIN app builder</param>
        /// <param name="options">The autheentication options</param>
        /// <returns>The OWIN app build</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IAppBuilder UsePowerBIAuthentication(this IAppBuilder app, PowerBIAuthenticationOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
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
                        return OnAuthorizationCodeReceivedAsync(context, options);
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

        /// <summary>
        /// Configures the application to use Azure AD with Power BI
        /// </summary>
        /// <param name="app">The OWIN app builder</param>
        /// <param name="setOptions">The action to set the authenciation options</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IAppBuilder UsePowerBIAuthentication(this IAppBuilder app, Action<PowerBIAuthenticationOptions> setOptions)
        {
            if (setOptions == null)
            {
                throw new ArgumentNullException(nameof(setOptions));
            }

            var options = new PowerBIAuthenticationOptions();
            setOptions(options);

            return UsePowerBIAuthentication(app, options);
        }

        private async static Task OnAuthorizationCodeReceivedAsync(AuthorizationCodeReceivedNotification context, PowerBIAuthenticationOptions options)
        {
            var code = context.Code;

            var credential = new ClientCredential(options.ClientId, options.ClientSecret);
            var tenantId = context.AuthenticationTicket.Identity.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
            var signedInUserId = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var authContext = new AuthenticationContext($"https://login.microsoftonline.com/{tenantId}", new TokenCache(Encoding.Default.GetBytes(signedInUserId)));
            var result = await authContext.AcquireTokenByAuthorizationCodeAsync(code, options.SuccessRedirectUri, credential, options.Resource);

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

                return powerBITokenCookie?.Value;
            });

            TokenManager.Current.SetTokenWriter((identity, accessToken) =>
            {
                var powerBITokenCookie = new HttpCookie(cookieKey, accessToken);
                HttpContext.Current.Response.Cookies.Add(powerBITokenCookie);
            });
        }
    }
}
