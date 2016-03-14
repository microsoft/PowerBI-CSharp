using System;
using System.Web.UI;
using Microsoft.PowerBI.Security;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;

namespace Microsoft.PowerBI.AspNet.WebForms.UI.WebControls
{
    public class Token : Control
    {
        public string AccessToken
        {
            get { return (string)this.ViewState["AccessToken"]; }
            set { this.ViewState["AccessToken"] = value; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (string.IsNullOrWhiteSpace(this.AccessToken))
            {
                this.AccessToken = GetAccessToken();
            }

            if (string.IsNullOrWhiteSpace(this.AccessToken))
            {
                var authProperties = new AuthenticationProperties { RedirectUri = this.Page.Request.Url.ToString() };
                HttpContext.Current
                    .GetOwinContext().Authentication
                    .Challenge(authProperties, OpenIdConnectAuthenticationDefaults.AuthenticationType);

                return;
            }

            var startUpScript = string.Format("window.powerbi = window.powerbi || {{}};{0}window.powerbi.accessToken = '{1}';", Environment.NewLine, this.AccessToken);
            if (!this.Page.ClientScript.IsStartupScriptRegistered(this.AccessToken))
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Token), this.AccessToken, startUpScript, true);
            }
        }

        private string GetAccessToken()
        {
            return TokenManager.Current.ReadToken(this.Page.User.Identity);
        }

        protected override void Render(HtmlTextWriter writer)
        {
        }
    }
}
