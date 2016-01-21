using Microsoft.PowerBI.Api;
using Microsoft.Rest;
using System;
using System.Web.UI;

namespace Microsoft.PowerBI.AspNet.WebForms.UI.WebControls
{
    public class Tile : Embed
    {
        public string TileId
        {
            get { return (string)this.ViewState["TileId"]; }
            set {
                this.ViewState["TileId"] = value;
                this.EmbedUrl = null;
            }
        }

        public string DashboardId
        {
            get { return (string)this.ViewState["DashboardId"]; }
            set {
                this.ViewState["DashboardId"] = value;
                this.EmbedUrl = null;
            }
        }

        public string OnClientClick
        {
            get { return (string)this.ViewState["OnClientClick"]; }
            set { this.ViewState["OnClientClick"] = value; }
        }

        protected override string GetEmbedUrl()
        {
            if(string.IsNullOrWhiteSpace(this.DashboardId) || string.IsNullOrWhiteSpace(this.TileId))
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
                var tile = client.Dashboards.GetTileByDashboardkeyAndTilekey(this.DashboardId, this.TileId);
                return tile.EmbedUrl;
            }
        }

        protected override string TagName
        {
            get { return "Tile"; }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);

            writer.AddAttribute("powerbi-tile", this.TileId);
            writer.AddAttribute("powerbi-dashboard", this.DashboardId);

            if (!string.IsNullOrWhiteSpace(this.OnClientClick))
            {
                writer.AddAttribute("ontileclick", this.OnClientClick);
            }

            if (!string.IsNullOrWhiteSpace(this.OnClientLoad))
            {
                writer.AddAttribute("ontileload", this.OnClientLoad);
            }
        }
    }
}
