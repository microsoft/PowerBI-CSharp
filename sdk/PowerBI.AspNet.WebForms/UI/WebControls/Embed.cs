using Microsoft.PowerBI.Security;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource("Microsoft.PowerBI.AspNet.WebForms.Resources.embed.js", "application/x-javascript")]
namespace Microsoft.PowerBI.AspNet.WebForms.UI.WebControls
{
    public abstract class Embed : WebControl
    {
        public Embed()
        {
            this.BaseUri = "https://api.powerbi.com";
        }

        public string BaseUri
        {
            get { return (string)this.ViewState["BaseUri"]; }
            set { this.ViewState["BaseUri"] = value; }
        }

        public string EmbedUrl
        {
            get { return (string)this.ViewState["EmbedUrl"]; }
            set { this.ViewState["EmbedUrl"] = value; }
        }

        public string CollectionName
        {
            get { return (string)this.ViewState["CollectionName"]; }
            set { this.ViewState["CollectionName"] = value; }
        }

        public string WorkspaceId
        {
            get { return (string)this.ViewState["WorkspaceId"]; }
            set { this.ViewState["WorkspaceId"] = value; }
        }

        public string OnClientLoad
        {
            get { return (string)this.ViewState["OnClientLoad"]; }
            set { this.ViewState["OnClientLoad"] = value; }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        protected virtual bool CanRender()
        {
            return !string.IsNullOrWhiteSpace(this.EmbedUrl);
        }

        protected abstract string GetEmbedUrl();

        protected string GetAccessToken()
        {
            return TokenManager.Current.ReadToken(this.Page.User.Identity);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (string.IsNullOrWhiteSpace(this.EmbedUrl))
            {
                this.EmbedUrl = this.GetEmbedUrl();
            }

            if (!this.CanRender())
            {
                return;
            }

            this.RegisterScripts();
        }

        private void RegisterScripts()
        {
            var scriptInclude = this.Page.ResolveUrl("~/scripts/powerbi.js");
            if (!this.Page.ClientScript.IsClientScriptIncludeRegistered(scriptInclude))
            {
                this.Page.ClientScript.RegisterClientScriptInclude(typeof(Embed), scriptInclude, scriptInclude);
            }
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute("powerbi-embed", this.EmbedUrl);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.CanRender())
            {
                return;
            }

            base.Render(writer);
        }
    }
}
