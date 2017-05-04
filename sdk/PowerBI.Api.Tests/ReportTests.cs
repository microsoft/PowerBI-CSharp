using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.V1;
using Microsoft.PowerBI.Api.V1.Models;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class ReportTests
    {
        private const string AccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private string groupId;

        [TestInitialize]
        public void TestInitialize()
        {
            this.groupId = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public async Task ReportDelete()
        {
            var deleteResponse = CreateSampleCloneReportResponse();

            var reportId = Guid.NewGuid().ToString();

            using (var handler = new FakeHttpClientHandler(deleteResponse))
            using (var client = CreatePowerBIClient(handler))
            {
                await client.Reports.DeleteReportAsync(reportId);

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/myorg/reports/{reportId}";
                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
                CheckAuthHeader(handler.Request.Headers.Authorization.ToString());
            }
        }

        [TestMethod]
        public async Task ReportDeleteInGroup()
        {
            var deleteResponse = CreateSampleCloneReportResponse();

            var reportId = Guid.NewGuid().ToString();

            using (var handler = new FakeHttpClientHandler(deleteResponse))
            using (var client = CreatePowerBIClient(handler))
            {
                await client.Reports.DeleteReportInGroupAsync(this.groupId, reportId);

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/myorg/groups/{this.groupId}/reports/{reportId}";
                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
                CheckAuthHeader(handler.Request.Headers.Authorization.ToString());
            }
        }

        [TestMethod]
        public async Task ReportRebind()
        {
            var rebindResponse = CreateSampleOKResponse();

            var reportId = Guid.NewGuid().ToString();
            var datasetId = Guid.NewGuid().ToString();

            using (var handler = new FakeHttpClientHandler(rebindResponse))
            using (var client = CreatePowerBIClient(handler))
            {
                await client.Reports.RebindReportAsync(reportId, new RebindReportRequest(datasetId));

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/myorg/reports/{reportId}/Rebind";

                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
                CheckAuthHeader(handler.Request.Headers.Authorization.ToString());
            }
        }

        private void CheckAuthHeader(string authHeader)
        {
            string expectedHeader = $"Bearer {AccessKey}";
            Assert.AreEqual<string>(authHeader, expectedHeader);
        }

        [TestMethod]
        public async Task ReportClone()
        {
            var cloneResponse = CreateSampleCloneReportResponse();

            var reportId = Guid.NewGuid().ToString();

            var cloneRequest = new CloneReportRequest()
            {
                TargetModelId = Guid.NewGuid().ToString(),
                Name = "Model Name",
                TargetGroupId = Guid.NewGuid().ToString()
            };

            using (var handler = new FakeHttpClientHandler(cloneResponse))
            using (var client = CreatePowerBIClient(handler))
            {
                var response = await client.Reports.CloneReportAsync(reportId, cloneRequest);

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/myorg/reports/{reportId}/Clone";

                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
                Assert.IsNotNull(response.Id);
                Assert.IsNotNull(response.EmbedUrl);
                Assert.IsNotNull(response.Name);
                Assert.IsNotNull(response.WebUrl);
                CheckAuthHeader(handler.Request.Headers.Authorization.ToString());
            }
        }

        private IPowerBIClient CreatePowerBIClient(HttpClientHandler handler)
        {
            var credentials = new TokenCredentials(AccessKey);
            return new PowerBIClient(credentials, handler);
        }

        private static HttpResponseMessage CreateSampleOKResponse(string name = default(string))
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(""))
            };
        }

        private static HttpResponseMessage CreateSampleCloneReportResponse(string name = default(string))
        {
            var report = new Report(Guid.NewGuid().ToString(), "Report Name", "AN URL", "EMBEDURL");

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(report))
            };
        }
    }
}
