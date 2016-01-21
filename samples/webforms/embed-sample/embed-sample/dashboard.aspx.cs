using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;
using System;

namespace embed_sample
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var accessToken = TokenManager.Current.ReadToken(this.User.Identity);
                if (string.IsNullOrWhiteSpace(accessToken))
                {
                    return;
                }

                var credentials = new TokenCredentials(accessToken);
                var baseUri = new Uri("https://api.powerbi.com");
                var client = new PowerBIClient(baseUri, credentials);

                var dashboardId = this.Request["dashboardId"];

                var dashboard = await client.Dashboards.GetDashboardByDashboardkeyAsync(dashboardId);
                var tiles = await client.Dashboards.GetTilesByDashboardkeyAsync(dashboardId);

                this.dashboardTitle.Text = dashboard.DisplayName;

                this.tileList.DataSource = tiles.Value;
                this.tileList.DataBind();
            }
        }
    }
}