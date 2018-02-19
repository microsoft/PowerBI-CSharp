using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class ImportsTests
    {
        private const string AccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private string groupId;

        [TestInitialize]
        public void TestInitialize()
        {
            this.groupId = Guid.NewGuid().ToString();
        }

        [TestMethod]
        public async Task PostImportWithFileWithNameAndConflict()
        {
            var datasetDisplayName = "TestDataset";
            var nameConflict = "Overwrite";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, nameConflict);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&nameConflict={nameConflict}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task Groups_PostImportWithFileWithNameAndConflict()
        {
            var datasetDisplayName = "TestDataset";
            var nameConflict = "Overwrite";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsyncInGroup(this.groupId, stream, datasetDisplayName, nameConflict);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/groups/{this.groupId}/imports?datasetDisplayName={datasetDisplayName}&nameConflict={nameConflict}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportFileWithName()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task Groups_PostImportFileWithName()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsyncInGroup(this.groupId, stream, datasetDisplayName);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/groups/{this.groupId}/imports?datasetDisplayName={datasetDisplayName}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        private static HttpResponseMessage CreateSampleImportResponse(string name = default(string))
        {
            var import = new Import
            {
                Id = Guid.NewGuid().ToString(),
                Name = name ?? "Sample",
                Datasets = new List<Dataset>(),
                Reports = new List<Report>(),
                ImportState = "Succeeded"
            };

            return new HttpResponseMessage(HttpStatusCode.Accepted)
            {
                Content = new StringContent(JsonConvert.SerializeObject(import))
            };
        }

        private IPowerBIClient CreatePowerBIClient(HttpClientHandler handler)
        {
            var credentials = new TokenCredentials(AccessKey);
            return new PowerBIClient(credentials, handler);
        }
    }
}
