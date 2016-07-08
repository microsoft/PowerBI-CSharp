using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.PowerBI.AspNet.Mvc.Html;
using System.Web.Mvc;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.AspNet.Mvc.Tests.Models;
using Microsoft.PowerBI.Api.V1.Models;

namespace Microsoft.PowerBI.AspNet.Mvc.Tests.Html
{
    [TestClass]
    public class ReportExtensionsTests
    {
        private HtmlHelper<ReportViewModel> htmlHelper;
        private Report report;
        private ReportViewModel viewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this.report = new Report
            {
                Id = "ce402b30-3611-4b26-a6a2-750a46a9f3e0",
                EmbedUrl = "https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5"
            };
            this.viewModel = new ReportViewModel { Report = this.report };
            this.htmlHelper = TestHelper.CreateHtmlHelper(new ViewDataDictionary<ReportViewModel>(this.viewModel));
        }

        [TestMethod]
        public void ReportWithEmbedUrl()
        {
            var expectedHtml = "<div id=\"myReport\" powerbi-embed-url=\"https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5\" powerbi-type=\"report\"></div>";
            var actualHtml = this.htmlHelper.PowerBIReport("myReport", this.viewModel.Report.EmbedUrl);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void ReportWithEmbedUrlAndAttrubites()
        {
            var expectedHtml = "<div class=\"powerbi-report\" id=\"myReport\" powerbi-embed-url=\"https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5\" powerbi-type=\"report\"></div>";
            var actualHtml = this.htmlHelper.PowerBIReport("myReport", this.viewModel.Report.EmbedUrl, new { @class = "powerbi-report" });

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void ReportWithReport()
        {
            var expectedHtml = "<div id=\"myReport\" powerbi-embed-url=\"https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5\" powerbi-type=\"report\"></div>";
            var actualHtml = this.htmlHelper.PowerBIReport("myReport", this.viewModel.Report);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void ReportWithReportAndAttrubites()
        {
            var expectedHtml = "<div class=\"powerbi-report\" id=\"myReport\" powerbi-embed-url=\"https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5\" powerbi-type=\"report\"></div>";
            var actualHtml = this.htmlHelper.PowerBIReport("myReport", this.viewModel.Report, new { @class = "powerbi-report" });

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void ReportForWithEmbedUrl()
        {
            var expectedHtml = "<div id=\"Report_EmbedUrl\" powerbi-embed-url=\"https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5\" powerbi-type=\"report\"></div>";
            var actualHtml = this.htmlHelper.PowerBIReportFor(m => m.Report.EmbedUrl);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void ReportForWithReport()
        {
            var expectedHtml = "<div id=\"Report\" powerbi-embed-url=\"https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5\" powerbi-type=\"report\"></div>";
            var actualHtml = this.htmlHelper.PowerBIReportFor(m => m.Report);

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }

        [TestMethod]
        public void ReportForWithEmbedUrlAndAttributes()
        {
            var expectedHtml = "<div class=\"powerbi-report\" id=\"Report_EmbedUrl\" powerbi-embed-url=\"https://msit.powerbi.com/reportEmbed?reportId=74e4fd97-aad6-4770-b460-a33b9d6411b5\" powerbi-type=\"report\" style=\"width:500px;height:500px;\"></div>";
            var actualHtml = this.htmlHelper.PowerBIReportFor(m => m.Report.EmbedUrl, new { @class = "powerbi-report", style = "width:500px;height:500px;" });

            Assert.AreEqual(expectedHtml, actualHtml.ToHtmlString());
        }
    }
}
