using System;
using System.Web;
using System.Web.UI;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;

namespace embed_sample.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var authProperties = new AuthenticationProperties { RedirectUri = this.Page.Request.Url.ToString() };
            HttpContext.Current
                .GetOwinContext().Authentication
                .Challenge(authProperties, OpenIdConnectAuthenticationDefaults.AuthenticationType);

        }
    }
}