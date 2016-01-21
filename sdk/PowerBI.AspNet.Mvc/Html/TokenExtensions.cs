using Microsoft.PowerBI.Security;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Microsoft.PowerBI.AspNet.Mvc.Html
{
    public static class TokenExtensions
    {
        public static MvcHtmlString PowerBIAccessToken(this HtmlHelper htmlHelper, string accessToken = null)
        {
            return TokenHelper(htmlHelper, accessToken);
        }

        public static MvcHtmlString PowerBIAccessTokenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return TokenHelper(htmlHelper, modelMetadata.Model as string);
        }

        private static MvcHtmlString TokenHelper(this HtmlHelper htmlHelper, string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                accessToken = TokenManager.Current.ReadToken(htmlHelper.ViewContext.RequestContext.HttpContext.User.Identity);
            }

            var script = string.Format("<script>window.powerbi = window.powerbi || {{}};{0}window.powerbi.accessToken = '{1}';</script>", Environment.NewLine, accessToken);
            return new MvcHtmlString(script);
        }
    }
}
