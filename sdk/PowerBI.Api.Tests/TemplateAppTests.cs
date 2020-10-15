using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class TemplateAppTests
    {
        private const string AccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private Guid appId;
        private string packageKey;
        private Guid ownerTenantId;

        [TestInitialize]
        public void TestInitialize()
        {
            this.appId = Guid.NewGuid();
            this.packageKey = "PackageSecureKey";
            this.ownerTenantId = Guid.NewGuid();
        }

        [TestMethod]
        public async Task CreateInstallTicket()
        {
            var installTicketReponse = CreateInstallTicketResponse(this.appId);

            var reportId = Guid.NewGuid();

            using (var handler = new FakeHttpClientHandler(installTicketReponse))
            using (var client = CreatePowerBIClient(handler))
            {
                var request = new CreateInstallTicketRequest
                {
                    InstallDetails = new List<TemplateAppInstallDetails> {
                        new TemplateAppInstallDetails
                        {
                            AppId = this.appId,
                            PackageKey = this.packageKey,
                            OwnerTenantId = this.ownerTenantId,
                            Config = new TemplateAppConfigurationRequest
                            {
                                Configuration = new Dictionary<string, string>()
                                {
                                    { "param1", "value1" }
                                }
                            }
                        }
                    }
                };
                await client.TemplateApps.CreateInstallTicketAsync(request);

                var expectedRequestUrl = $"https://api.powerbi.com/v1.0/myorg/CreateTemplateAppInstallTicket";
                Assert.AreEqual(expectedRequestUrl, handler.Request.RequestUri.ToString());
                CheckAuthHeader(handler.Request.Headers.Authorization.ToString());
            }
        }

        private void CheckAuthHeader(string authHeader)
        {
            string expectedHeader = $"Bearer {AccessKey}";
            Assert.AreEqual<string>(authHeader, expectedHeader);
        }

        private IPowerBIClient CreatePowerBIClient(HttpClientHandler handler)
        {
            var credentials = new TokenCredentials(AccessKey);
            return new PowerBIClient(credentials, handler);
        }

        private static HttpResponseMessage CreateInstallTicketResponse(Guid appId)
        {
            var ticket = new InstallTicket($"ticketContents{appId}", Guid.NewGuid(), DateTime.UtcNow.AddMinutes(10));

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(ticket))
            };
        }
    }
}
