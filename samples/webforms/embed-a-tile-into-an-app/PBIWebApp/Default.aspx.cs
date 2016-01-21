using System;
using System.Web;
using System.Web.UI;
using Microsoft.Rest;
using Microsoft.PowerBI.Api.Beta;
using Microsoft.PowerBI.Security;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;

namespace PBIWebApp
{
    /* NOTE: This sample is to illustrate how to authenticate a Power BI web app. 
    * In a production application, you should provide appropriate exception handling and refactor authentication settings into 
    * a secure configuration. Authentication settings are hard-coded in the sample to make it easier to follow the flow of authentication. */
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.User.Identity.IsAuthenticated)
            {
                //Show Power BI Sign In Panel
                signInStatus.Visible = true;

                //Set user and toek from authentication result
                userLabel.Text = this.User.Identity.Name;
                accessTokenTextbox.Text = TokenManager.Current.ReadToken(this.User.Identity);
            }
            else
            {
                PBIPanel.Visible = false;
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

        private IPowerBIClient GetPowerBIClient()
        {
            var baseUri = new Uri("https://api.powerbi.com");
            var credentials = new TokenCredentials(TokenManager.Current.ReadToken(this.Page.User.Identity));
            return new PowerBIClient(baseUri, credentials);
        }

        protected async void getGroupsButton_Click(object sender, EventArgs e)
        {
            using (var client = GetPowerBIClient())
            {
                var groups = await client.Groups.GetGroupsAsync();
                foreach (var group in groups.Value)
                {
                    tb_GroupsResults.Text += String.Format("{0}\t{1}\n", group.Id, group.Name);
                }
            }
        }

        protected async void getDatasetsButton_Click(object sender, EventArgs e)
        {
            using (var client = GetPowerBIClient())
            {
                var datasets = await client.Datasets.GetDatasetsAsync();
                foreach (var dataset in datasets.Value)
                {
                    resultsTextbox.Text += String.Format("{0}\t{1}\n", dataset.Id, dataset.Name);
                }
            }
        }

        //Embed
        protected async void getDashboardsButton_Click(object sender, EventArgs e)
        {
            using (var client = GetPowerBIClient())
            {
                var dashboards = await client.Dashboards.GetDashboardsAsync();
                foreach (var dashboard in dashboards.Value)
                {
                    tb_dashboardsResult.Text += String.Format("{0}\t{1}\n", dashboard.Id, dashboard.DisplayName);
                }
            }
        }

        //Embed
        protected async void getTilesButton_Click(object sender, EventArgs e)
        {
            string responseContent = string.Empty;
            string dashboardId = string.Empty;

            if (string.Empty == inDashboardID.Text)
            {
                tb_tilesResult.Text = "Please enter a dashboard id above";
                return;
            }

            dashboardId = inDashboardID.Text;

            using (var client = GetPowerBIClient())
            {
                var tiles = await client.Dashboards.GetTilesByDashboardkeyAsync(dashboardId);
                foreach (var tile in tiles.Value)
                {
                    tb_tilesResult.Text += String.Format("{0}\t{1}\t{2}\n", tile.Id, tile.Title, tile.EmbedUrl);
                }
            }
        }

        protected void embedButton_Click(object sender, EventArgs e)
        {
            this.pbiTile.DashboardId = inDashboardID.Text;
            this.pbiTile.TileId = txtTileId.Text;
            this.pbiTile.Visible = true;
        }
    }
}