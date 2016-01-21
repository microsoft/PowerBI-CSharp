using System;
using System.Web;
using System.Web.UI;
using Microsoft.PowerBI.Api.Beta;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;

namespace PBIWebApp
{
    /* NOTE: This sample is to illustrate how to authenticate a Power BI web app. 
    * In a production application, you should provide appropriate exception handling and refactor authentication settings into 
    * a configuration. Authentication settings are hard-coded in the sample to make it easier to follow the flow of authentication. */
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                //Show Power BI Sign In Panel
                signInStatus.Visible = true;

                //Set user and toek from authentication result
                userLabel.Text = this.User.Identity.Name;
                accessTokenTextbox.Text = TokenManager.Current.ReadToken(this.User.Identity);
            }
        }

        protected void signInButton_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }

        protected async void getReportsButton_Click(object sender, EventArgs e)
        {
            // Configure the Power BI Client
            var baseUri = new Uri("https://api.powerbi.com");
            var credentials = new TokenCredentials(TokenManager.Current.ReadToken(this.User.Identity));
            using (var powerBIClient = new PowerBIClient(baseUri, credentials))
            {
                var reports = await powerBIClient.Reports.GetReportsAsync();

                foreach (var report in reports.Value)
                {
                    tb_reportsResult.Text += String.Format("{0}\t{1}\t{2}\n", report.Id, report.Name, report.EmbedUrl);
                }
            }
        }

        protected void btnEmbed_Click(object sender, EventArgs e)
        {
            pbiReport.EmbedUrl = txtEmbedUrl.Text;
            pbiReport.Visible = true;
        }
    }
}