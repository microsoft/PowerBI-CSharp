using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerBI.Api.Tests.V2
{
    [TestClass]
    public class ExceptionTests
    {

        private const string AccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        [TestMethod]
        public void MissingGroup()
        {
            var serverResponse = @"{""error"":{""code"":""InvalidRequest"",""message"":""datasetId is null or empty""}}";
            var response = CreateSampleBadResponse(serverResponse);
            Exception actualException = null;
            PowerBIError error = null;

            using (var handler = new FakeHttpClientHandler(response))
            using (var client = CreatePowerBIClient(handler))
            {
                try
                {
                    client.Reports.GenerateTokenForCreate(new GenerateTokenRequest("Create"));
                }
                catch (Exception exception)
                {
                    actualException = exception;
                    error = client.GetError(exception);
               }
            }

            Assert.IsNotNull(actualException);
            Assert.AreEqual("Operation returned an invalid status code 'BadRequest'", actualException.Message);

            Assert.AreEqual("datasetId is null or empty", error.Message);
            Assert.AreEqual("InvalidRequest", error.Code);
        }

        [TestMethod]
        public void ImportException()
        {
            var serverResponse = @"{""error"":{""code"":""InvalidRequest"",""message"":""datasetId is null or empty""}}";
            var response = CreateSampleBadResponse(serverResponse);
            response.Headers.Add("X-PowerBI-Error-Details", serverResponse);

            Exception actualException = null;
            PowerBIError error = null;

            using (var handler = new FakeHttpClientHandler(response))
            using (var client = CreatePowerBIClient(handler))
            {
                try
                {
                    using(var ms = new MemoryStream())
                    client.Imports.PostImportWithFile(ms);
                }
                catch (Exception exception)
                {
                    actualException = exception;
                    error = client.GetError(exception);
                }
            }

            Assert.IsNotNull(actualException);
            Assert.AreEqual("Operation returned an invalid status code 'BadRequest'", actualException.Message);
            Assert.AreEqual(serverResponse, ((HttpOperationException)actualException).Response.Headers["X-PowerBI-Error-Details"].First());
            Assert.AreEqual(serverResponse, ((HttpOperationException)actualException).Response.Content);



            Assert.AreEqual("datasetId is null or empty", error.Message);
            Assert.AreEqual("InvalidRequest", error.Code);
        }

        [TestMethod]
        public void MissingGroup_With_BadJson()
        {
            var serverResponse = @"{""error"":{""code"":""InvalidRequest"",""badJason"":""datasetId is null or empty""}}";
            var response = CreateSampleBadResponse(serverResponse);
            Exception actualException = null;
            PowerBIError error = null;

            using (var handler = new FakeHttpClientHandler(response))
            using (var client = CreatePowerBIClient(handler))
            {
                try
                {
                    client.Reports.GenerateTokenForCreate(new GenerateTokenRequest("Create"));
                }
                catch (Exception exception)
                {
                    actualException = exception;
                    error = client.GetError(exception);
                }
            }

            Assert.IsNotNull(actualException);
            Assert.AreEqual("Operation returned an invalid status code 'BadRequest'", actualException.Message);
            Assert.IsNotNull(error);
        }

        private IPowerBIClient CreatePowerBIClient(HttpClientHandler handler)
        {
            var credentials = new TokenCredentials(AccessKey);
            return new PowerBIClient(credentials, handler);
        }

        private static HttpResponseMessage CreateSampleBadResponse(string content = default(string))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(content)
            };
        }
    }
}
