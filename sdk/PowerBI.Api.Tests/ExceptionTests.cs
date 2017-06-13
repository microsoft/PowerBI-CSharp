using System;
using System.Net;
using System.Net.Http;
using Microsoft.PowerBI.Api.V1;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class ExceptionTests
    {
        private const string AccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        [TestMethod]
        public void MissingGroup()
        {
            var serverResponse = @"{""error"":{""code"":""InvalidRequest"",""message"":""Real Error message from server""}}";
            var response = CreateSampleBadResponse(serverResponse);
            Exception actualException = null;

            using (var handler = new FakeHttpClientHandler(response))
            using (var client = CreatePowerBIClient(handler))
            {
                try
                {
                    client.Reports.DeleteReport("a", "b", "c");
                }
                catch (Exception exception)
                {
                    actualException = exception;
                }
            }
            Assert.IsNotNull(actualException);
            Assert.AreEqual("Operation returned an invalid status code 'BadRequest'", actualException.Message);

            //Emulate logger  //Note, not sign of the "datasetId is null message :(
            Assert.IsTrue(actualException.ToString().StartsWith("Microsoft.Rest.HttpOperationException: Operation returned an invalid status code 'BadRequest'"));
            var httpException = (HttpOperationException)actualException;
            Assert.AreEqual("Operation returned an invalid status code 'BadRequest'", httpException.ToString());
            Assert.AreEqual(serverResponse, httpException.Response.Content); //The real message

            Assert.IsTrue(actualException.StackTrace.Contains("at Microsoft.PowerBI.Api.V1.Reports.<DeleteReportWithHttpMessagesAsync>"));
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
