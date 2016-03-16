using System;
using System.Web.UI;
using Microsoft.PowerBI.Security;

namespace Microsoft.PowerBI.AspNet.WebForms.UI.WebControls
{
    /// <summary>
    /// The Power BI token Web Control
    /// </summary>
    public class Token : Control
    {
        /// <summary>
        /// The power bi access token to make available to the web application
        /// </summary>
        public string AccessToken
        {
            get { return (string)this.ViewState["AccessToken"]; }
            set { this.ViewState["AccessToken"] = value; }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data. </param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (string.IsNullOrWhiteSpace(this.AccessToken))
            {
                this.AccessToken = GetAccessToken();
            }

            var startUpScript = $"window.powerbi = window.powerbi || {{}};{Environment.NewLine}window.powerbi.accessToken = '{this.AccessToken}';";
            if (!this.Page.ClientScript.IsStartupScriptRegistered(this.AccessToken))
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Token), this.AccessToken, startUpScript, true);
            }
        }

        private string GetAccessToken()
        {
            return TokenManager.Current.ReadToken(this.Page.User.Identity);
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"/> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the server control content. </param>
        protected override void Render(HtmlTextWriter writer)
        {
        }
    }
}
