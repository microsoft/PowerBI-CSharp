using Microsoft.PowerBI.Api.Beta;
using Microsoft.Rest;
using System;
using System.Linq;
using System.Web.UI;

namespace Microsoft.PowerBI.AspNet.WebForms.UI.WebControls
{
    public class Report : Embed
    {
        public string ReportId
        {
            get { return (string)this.ViewState["ReportId"]; }
            set {
                this.ViewState["ReportId"] = value;
                this.EmbedUrl = null;
            }
        }

        protected override string TagName
        {
            get { return "Report"; }
        }

        protected override string GetEmbedUrl()
        {
            if (string.IsNullOrWhiteSpace(this.ReportId))
            {
                return null;
            }

            var accessToken = base.GetAccessToken();
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return null;
            }

            var credentials = new TokenCredentials(accessToken);
            using (var client = new PowerBIClient(new Uri(this.BaseUri), credentials))
            {
                var report = client.Reports.GetReports().Value.FirstOrDefault(r => r.Id == this.ReportId);
                return report == null ? null : report.EmbedUrl;
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute("powerbi-report", this.ReportId);

            if (!string.IsNullOrWhiteSpace(this.OnClientLoad))
            {
                writer.AddAttribute("onreportload", this.OnClientLoad);
            }
        }
    }
}
