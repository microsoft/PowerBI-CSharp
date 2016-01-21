using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Microsoft.PowerBI.AspNet.Mvc.Html
{
    public static class TileExtensions
    {
        /// <summary>
        /// Renders a Power BI Tile for the specified Tile object
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="name">The name to associate to the HTML element</param>
        /// <param name="tile">The Power BI Tile</param>
        /// <param name="htmlAttributes">Additional attributes used while rendering the report</param>
        /// <returns></returns>
        public static MvcHtmlString PowerBITile(this HtmlHelper htmlHelper, string name, ITile tile, object htmlAttributes = null)
        {
            return TileHelper(htmlHelper, null, tile, name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Renders a Power BI Tile for the specified tile embed url
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="name">The name to associate to the HTML element</param>
        /// <param name="embedUrl">The tile embed url</param>
        /// <param name="htmlAttributes">Additional attributes used while rendering the report</param>
        /// <returns></returns>
        public static MvcHtmlString PowerBITile(this HtmlHelper htmlHelper, string name, string embedUrl, object htmlAttributes = null)
        {
            var tile = new Tile { EmbedUrl = embedUrl };
            return TileHelper(htmlHelper, null, tile, name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Renders a Power BI Tile for the specified tile expression
        /// </summary>
        /// <typeparam name="TModel">The view model</typeparam>
        /// <typeparam name="TProperty">The Tile type</typeparam>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="expression">The Tile expression</param>
        /// <param name="htmlAttributes">Additional attributes used while rendering the report</param>
        /// <returns></returns>
        public static MvcHtmlString PowerBITileFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            return TileHelper(htmlHelper, modelMetadata, modelMetadata.Model, ExpressionHelper.GetExpressionText(expression), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString TileHelper(this HtmlHelper htmlHelper, ModelMetadata metadata, object value, string expression, IDictionary<string, object> htmlAttributes)
        {
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);

            var embedUrl = value as string;
            ITile tile = null;

            if (string.IsNullOrWhiteSpace(embedUrl))
            {
                tile = value as ITile;
                if (tile != null)
                {
                    embedUrl = tile.EmbedUrl;
                }
            }

            var tagBuilder = new TagBuilder("div");
            tagBuilder.MergeAttributes(htmlAttributes, true);
            tagBuilder.MergeAttribute("powerbi-embed", embedUrl, true);
            tagBuilder.MergeAttribute("powerbi-tile", (tile == null ? null : tile.Id), true);
            tagBuilder.GenerateId(fullHtmlFieldName);

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}
