using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;
using System;

namespace embed_sample
{
    public partial class dashboards : System.Web.UI.Page
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

                var dashboards = await client.Dashboards.GetDashboardsAsync();
                this.dashboardList.DataSource = dashboards.Value;
                this.dashboardList.DataBind();
            }
        }

        protected void dashboardLink_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            this.Response.Redirect("~/dashboard.aspx?dashboardId=" + e.CommandArgument.ToString());
        }
    }
}