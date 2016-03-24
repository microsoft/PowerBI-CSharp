using Microsoft.PowerBI.Security;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Microsoft.PowerBI.AspNet.WebForms.UI.WebControls
{
    /// <summary>
    /// Base class for all Power BI embed controls
    /// </summary>
    public abstract class Embed : WebControl
    {
        /// <summary>
        /// Creates a new instance of the embed control
        /// </summary>
        protected Embed()
        {
            this.BaseUri = "https://api.powerbi.com";
        }

        /// <summary>
        /// The base uri
        /// </summary>
        public string BaseUri
        {
            get { return (string)this.ViewState["BaseUri"]; }
            set { this.ViewState["BaseUri"] = value; }
        }

        /// <summary>
        /// The embed url for this component
        /// </summary>
        public string EmbedUrl
        {
            get { return (string)this.ViewState["EmbedUrl"]; }
            set { this.ViewState["EmbedUrl"] = value; }
        }

        /// <summary>
        /// The workspace collection name
        /// </summary>
        public string CollectionName
        {
            get { return (string)this.ViewState["CollectionName"]; }
            set { this.ViewState["CollectionName"] = value; }
        }

        /// <summary>
        /// The workspace id
        /// </summary>
        public string WorkspaceId
        {
            get { return (string)this.ViewState["WorkspaceId"]; }
            set { this.ViewState["WorkspaceId"] = value; }
        }

        /// <summary>
        /// The client side load event to call after the component is loaded
        /// </summary>
        public string OnClientLoad
        {
            get { return (string)this.ViewState["OnClientLoad"]; }
            set { this.ViewState["OnClientLoad"] = value; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> value that corresponds to this Web server control. This property is used primarily by control developers.
        /// </summary>
        /// <returns>
        /// One of the <see cref="T:System.Web.UI.HtmlTextWriterTag"/> enumeration values.
        /// </returns>
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }

        /// <summary>
        /// Specifies whether this component can render 
        /// </summary>
        /// <returns></returns>
        protected virtual bool CanRender()
        {
            return !string.IsNullOrWhiteSpace(this.EmbedUrl);
        }

        /// <summary>
        /// Gets the embed url for this component
        /// </summary>
        /// <returns></returns>
        protected abstract string GetEmbedUrl();

        /// <summary>
        /// Gets the access token for this component
        /// </summary>
        /// <returns></returns>
        protected string GetAccessToken()
        {
            return TokenManager.Current.ReadToken(this.Page.User.Identity);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data. </param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            writer.AddAttribute("powerbi-embed", this.EmbedUrl);
        }

        /// <summary>
        /// Renders the contents of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client. </param>
        protected override void RenderContents(HtmlTextWriter writer)
        {
        }

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter"/> object that receives the control content. </param>
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
