using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Beta.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Microsoft.PowerBI.AspNet.Mvc.Html
{
    /// <summary>
    /// The Power BI Report Html Helper
    /// </summary>
    public static class ReportExtensions
    {
        /// <summary>
        /// Renders a Power BI report based on the specified report
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="name">The name to associate with this report</param>
        /// <param name="report">The Power BI report</param>
        /// <param name="htmlAttributes">Additional attributes used while rendering the report</param>
        /// <returns></returns>
        public static MvcHtmlString PowerBIReport(this HtmlHelper htmlHelper, string name, IReport report, object htmlAttributes = null)
        {
            return ReportHelper(htmlHelper, null, report, name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Renders a Power BI report based on the specified embedUrl
        /// </summary>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="name">The name to associate with this report</param>
        /// <param name="embedUrl">The report embed url</param>
        /// <param name="htmlAttributes">Additional attributes used while rendering the report</param>
        /// <returns></returns>
        public static MvcHtmlString PowerBIReport(this HtmlHelper htmlHelper, string name, string embedUrl, object htmlAttributes = null)
        {
            var report = new Report { EmbedUrl = embedUrl };
            return ReportHelper(htmlHelper, null, report, name, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        /// <summary>
        /// Renders the Power BI report based on the specified report expression
        /// </summary>
        /// <typeparam name="TModel">The view mode.</typeparam>
        /// <typeparam name="TProperty">The property containing your report</typeparam>
        /// <param name="htmlHelper">The HTML helper</param>
        /// <param name="expression">The report expression</param>
        /// <param name="htmlAttributes">Additional attributes used while rendering the report</param>
        /// <returns></returns>
        public static MvcHtmlString PowerBIReportFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            return ReportHelper(htmlHelper, modelMetadata, modelMetadata.Model, ExpressionHelper.GetExpressionText(expression), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString ReportHelper(this HtmlHelper htmlHelper, ModelMetadata metadata, object value, string expression, IDictionary<string, object> htmlAttributes)
        {
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);

            var embedUrl = value as string;
            IReport report = null;

            if (string.IsNullOrWhiteSpace(embedUrl))
            {
                report = value as IReport;
                if (report != null)
                {
                    embedUrl = report.EmbedUrl;
                }
            }

            var tagBuilder = new TagBuilder("div");
            tagBuilder.MergeAttributes(htmlAttributes, true);
            tagBuilder.MergeAttribute("powerbi-embed", embedUrl, true);
            tagBuilder.MergeAttribute("powerbi-report", (report == null ? null : report.Id), true);
            tagBuilder.GenerateId(fullHtmlFieldName);

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}
