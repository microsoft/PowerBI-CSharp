using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.PowerBI.Security;

namespace Microsoft.PowerBI.AspNet.Mvc.Html
{
    /// <summary>
    /// Power BI Token HTML Helper 
    /// </summary>
    public static class TokenExtensions
    {
        /// <summary>
        /// Renders the specified access token to the DOM
        /// </summary>
        /// <param name="htmlHelper">The html helper</param>
        /// <param name="accessToken">The access token to include</param>
        /// <returns></returns>
        public static IHtmlString PowerBIAccessToken(this HtmlHelper htmlHelper, string accessToken = null)
        {
            return TokenHelper(htmlHelper, accessToken);
        }

        /// <summary>
        /// Renders the specified access token to the DOM
        /// </summary>
        /// <param name="htmlHelper">The html helper</param>
        /// <param name="expression">The expression to retrieve the access token</param>
        /// <typeparam name="TModel">The model type</typeparam>
        /// <typeparam name="TProperty">The property type</typeparam>
        /// <returns></returns>
        public static IHtmlString PowerBIAccessTokenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return TokenHelper(htmlHelper, modelMetadata.Model as string);
        }

        private static IHtmlString TokenHelper(this HtmlHelper htmlHelper, string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                accessToken = TokenManager.Current.ReadToken(htmlHelper.ViewContext.RequestContext.HttpContext.User.Identity);
            }

            var script = $"<script>window.powerbi = window.powerbi || {{}};{Environment.NewLine}window.powerbi.accessToken = '{accessToken}';</script>";
            return new HtmlString(script);
        }
    }
}
