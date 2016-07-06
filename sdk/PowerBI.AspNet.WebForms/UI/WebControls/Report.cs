using Microsoft.Rest;
using System;
using System.Linq;
using System.Web.UI;
using Microsoft.PowerBI.Api.V1;

namespace Microsoft.PowerBI.AspNet.WebForms.UI.WebControls
{
    /// <summary>
    /// The Power BI Report Web Control
    /// </summary>
    public class Report : Embed
    {
        /// <summary>
        /// The report id
        /// </summary>
        public string ReportId
        {
            get { return (string)this.ViewState["ReportId"]; }
            set {
                this.ViewState["ReportId"] = value;
                this.EmbedUrl = null;
            }
        }

        /// <summary>
        /// Gets the tag name for the Report control
        /// </summary>
        protected override string TagName => "Report";

        /// <summary>
        /// Gets the embed url for the report to render
        /// </summary>
        /// <returns></returns>
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
                var report = client.Reports.GetReports(this.CollectionName, this.WorkspaceId).Value.FirstOrDefault(r => r.Id == this.ReportId);
                return report?.EmbedUrl;
            }
        }

        /// <summary>
        /// Add the attributes required for rending this component
        /// </summary>
        /// <param name="writer"></param>
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
