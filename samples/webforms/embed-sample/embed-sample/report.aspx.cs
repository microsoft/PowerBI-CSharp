using Microsoft.PowerBI.Api.Beta;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace embed_sample
{
    public partial class report : System.Web.UI.Page
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

                var reports = await client.Reports.GetReportsAsync();
                this.reportList.DataSource = reports.Value;
                this.pbiReport.ReportId = reports.Value[0].Id;
                this.reportList.DataBind();
            }
        }

        protected void reportLink_Command(object sender, CommandEventArgs e)
        {
            pbiReport.ReportId = e.CommandArgument.ToString();
        }
    }
}