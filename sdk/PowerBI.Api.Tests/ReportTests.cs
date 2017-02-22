using System;
using System.Collections.Generic;
using System.IO;
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

        private string workspaceCollectionName;
        private string workspaceId;

        [TestInitialize]
        public void TestInitialize()
        {
            this.workspaceCollectionName = "WC";
            this.workspaceId = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public async Task ReportDelete()
        {
            var deleteResponse = CreateSampleDeleteReportResponse();

            var reportId = Guid.NewGuid().ToString();

            using (var handler = new FakeHttpClientHandler(deleteResponse))
            using (var client = CreatePowerBIClient(handler))
            {
                await client.Reports.DeleteReportAsync(this.workspaceCollectionName, this.workspaceId, reportId);

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/collections/{this.workspaceCollectionName}/workspaces/{this.workspaceId}/reports/{reportId}";
                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task ReportRebind()
        {
            var deleteResponse = CreateSampleRebindReportResponse();

            var reportId = Guid.NewGuid().ToString();
            var datasetId = Guid.NewGuid().ToString();

            using (var handler = new FakeHttpClientHandler(deleteResponse))
            using (var client = CreatePowerBIClient(handler))
            {
                await client.Reports.RebindReportAsync(this.workspaceCollectionName, this.workspaceId, reportId, new RebindReportRequest(datasetId));

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/collections/{this.workspaceCollectionName}/workspaces/{this.workspaceId}/reports/{reportId}/Rebind";

                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task ReportClone()
        {
            var deleteResponse = CreateSampleCloneReportResponse();

            var reportId = Guid.NewGuid().ToString();

            var cloneRequest = new CloneReportRequest()
            {
                TargetModelId = Guid.NewGuid().ToString(),
                Name = "A Name",
                TargetWorkspaceId = Guid.NewGuid().ToString()
            };

            using (var handler = new FakeHttpClientHandler(deleteResponse))
            using (var client = CreatePowerBIClient(handler))
            {
                await client.Reports.CloneReportAsync(this.workspaceCollectionName, this.workspaceId, reportId, cloneRequest);

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/collections/{this.workspaceCollectionName}/workspaces/{this.workspaceId}/reports/{reportId}/Clone";

                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
            }
        }

        private IPowerBIClient CreatePowerBIClient(HttpClientHandler handler)
        {
            var credentials = new TokenCredentials(AccessKey);
            return new PowerBIClient(credentials, handler);
        }

        private static HttpResponseMessage CreateSampleDeleteReportResponse(string name = default(string))
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(""))
            };
        }

        private static HttpResponseMessage CreateSampleRebindReportResponse(string name = default(string))
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(""))
            };
        }

        private static HttpResponseMessage CreateSampleCloneReportResponse(string name = default(string))
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(""))
            };
        }
    }
}
