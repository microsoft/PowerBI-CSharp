using Microsoft.PowerBI.AspNet.Mvc.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Microsoft.PowerBI.AspNet.Mvc.Html;
using Microsoft.PowerBI.Security;
using System.Security.Principal;

namespace Microsoft.PowerBI.AspNet.Mvc.Tests.Html
{
    [TestClass]
    public class TokenExtensionsTests
    {
        private HtmlHelper<CustomViewModel> htmlHelper;
        private CustomViewModel viewModel;
        private IPrincipal principal;
        private string accessToken;

        [TestInitialize]
        public void TestInitialize()
        {
            TokenManager.Current.Clear();

            this.accessToken = "DEF456";
            this.principal = new GenericPrincipal(new GenericIdentity("TestUser", "Test"), new string[0]);
            this.viewModel = new CustomViewModel { AccessToken = this.accessToken };
            this.htmlHelper = TestHelper.CreateHtmlHelper(new ViewDataDictionary<CustomViewModel>(this.viewModel), this.principal);
        }

        [TestMethod]
        public void AccessTokenWithToken()
        {
            var expectedHtml = "<script>window.powerbi = window.powerbi || {};\r\nwindow.powerbi.accessToken = 'DEF456';</script>";
            var actualHtml = this.htmlHelper.PowerBIAccessToken(this.viewModel.AccessToken);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void AccessTokenForWithToken()
        {
            var expectedHtml = "<script>window.powerbi = window.powerbi || {};\r\nwindow.powerbi.accessToken = 'DEF456';</script>";
            var actualHtml = this.htmlHelper.PowerBIAccessTokenFor(m => m.AccessToken);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void AccessTokenWithoutToken()
        {
            TokenManager.Current.WriteToken(this.htmlHelper.ViewContext.RequestContext.HttpContext.User.Identity, this.accessToken);

            var expectedHtml = "<script>window.powerbi = window.powerbi || {};\r\nwindow.powerbi.accessToken = 'DEF456';</script>";
            var actualHtml = this.htmlHelper.PowerBIAccessToken();

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void AccessTokenWithoutAnyToken()
        {
            var expectedHtml = "<script>window.powerbi = window.powerbi || {};\r\nwindow.powerbi.accessToken = '';</script>";
            var actualHtml = this.htmlHelper.PowerBIAccessToken();

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }
    }
}
