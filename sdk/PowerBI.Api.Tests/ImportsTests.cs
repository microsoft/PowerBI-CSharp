using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class ImportsTests
    {
        private const string AccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private Guid groupId;

        [TestInitialize]
        public void TestInitialize()
        {
            this.groupId = Guid.NewGuid();
        }

        [TestMethod]
        public async Task PostImportWithFileWithNameAndConflict()
        {
            var datasetDisplayName = "TestDataset";
            var nameConflict = ImportConflictHandlerMode.Overwrite;
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
        public async Task Groups_PostImportWithFileWithNameAndConflictAsync()
        {
            var datasetDisplayName = "TestDataset";
            var nameConflict = ImportConflictHandlerMode.Overwrite;
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
        public void Groups_PostImportWithFileWithNameAndConflict()
        {
            var datasetDisplayName = "TestDataset";
            var nameConflict = ImportConflictHandlerMode.Overwrite;
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                client.Imports.PostImportWithFileInGroup(this.groupId, stream, datasetDisplayName, nameConflict);
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
        public async Task Groups_PostImportFileWithNameAsync()
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

        [TestMethod]
        public void Groups_PostImportFileWithName()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                client.Imports.PostImportWithFileInGroup(this.groupId, stream, datasetDisplayName);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/groups/{this.groupId}/imports?datasetDisplayName={datasetDisplayName}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportFileWithNameAndSkipReport()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, skipReport: true);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&skipReport=True";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public void Group_PostImportFileWithNameAndSkipReport()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                client.Imports.PostImportWithFileInGroup(this.groupId, stream, datasetDisplayName, skipReport: true);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/groups/{this.groupId}/imports?datasetDisplayName={datasetDisplayName}&skipReport=True";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task Group_PostImportFileWithNameAndSkipReportAsync()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsyncInGroup(this.groupId, stream, datasetDisplayName, skipReport: true);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/groups/{this.groupId}/imports?datasetDisplayName={datasetDisplayName}&skipReport=True";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportFileWithNameAndNotOverrideReport()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();
            var overrideReportLabel = false;

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, overrideReportLabel: overrideReportLabel);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&overrideReportLabel={overrideReportLabel}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportFileWithNameAndNotOverrideModel()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();
            var overrideModelLabel = false;

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, overrideModelLabel: overrideModelLabel);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&overrideModelLabel={overrideModelLabel}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportFileWithNameAndNotOverrideLabels()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();
            var overrideReportLabel = false;
            var overrideModelLabel = false;

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, overrideReportLabel: overrideReportLabel, overrideModelLabel: overrideModelLabel);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&overrideReportLabel={overrideReportLabel}&overrideModelLabel={overrideModelLabel}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportFileWithNameAndOverrideLabels()
        {
            var datasetDisplayName = "TestDataset";
            var importResponse = CreateSampleImportResponse();
            var overrideReportLabel = true;
            var overrideModelLabel = true;

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, overrideReportLabel: overrideReportLabel, overrideModelLabel: overrideModelLabel);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&overrideReportLabel={overrideReportLabel}&overrideModelLabel={overrideModelLabel}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportWithFileWithNameAndConflictAndSkipReport()
        {
            var datasetDisplayName = "TestDataset";
            var nameConflict = ImportConflictHandlerMode.Overwrite;
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, nameConflict, skipReport: true);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&nameConflict={nameConflict}&skipReport=True";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        [TestMethod]
        public async Task PostImportWithFileWithNameAndSubfolderObjectId()
        {
            var datasetDisplayName = "TestDataset";
            Guid subfolderObjectId = new Guid();
            var importResponse = CreateSampleImportResponse();

            using (var handler = new FakeHttpClientHandler(importResponse))
            using (var client = CreatePowerBIClient(handler))
            using (var stream = new MemoryStream())
            {
                await client.Imports.PostImportWithFileAsync(stream, datasetDisplayName, subfolderObjectId: subfolderObjectId);
                var expectedRequesetUrl = $"https://api.powerbi.com/v1.0/myorg/imports?datasetDisplayName={datasetDisplayName}&subfolderObjectId={subfolderObjectId}";
                Assert.AreEqual(expectedRequesetUrl, handler.Request.RequestUri.ToString());
            }
        }

        private static HttpResponseMessage CreateSampleImportResponse(string name = default(string))
        {
            var import = new Import
            {
                Id = Guid.NewGuid(),
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
