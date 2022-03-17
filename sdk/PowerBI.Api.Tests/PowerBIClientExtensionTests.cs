using Microsoft.PowerBI.Api;
using Microsoft.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class PowerBIClientExtensionTests
    {
        private readonly string c_servicePrincipalProfileHeaderName = "X-PowerBI-profile-id";
        private readonly ServiceClientCredentials c_credentials = new BasicAuthenticationCredentials();


        [TestMethod]
        public void VerifyCreateClientWithoutProfile()
        {
            var powerBIClient = new PowerBIClient(credentials: c_credentials);
            Assert.IsFalse(powerBIClient.HttpClient.DefaultRequestHeaders.Contains(c_servicePrincipalProfileHeaderName));
        }

        [TestMethod]
        public void VerifyCreateClientWithProfile()
        {
            var profileObjectId = Guid.NewGuid();
            var powerBIClient = new PowerBIClient(credentials: c_credentials, profileObjectId: profileObjectId);
            Assert.IsTrue(powerBIClient.HttpClient.DefaultRequestHeaders.Contains(c_servicePrincipalProfileHeaderName));
            var profileHeaderValue = powerBIClient.GetServicePrincipalProfileObjectId();
            Assert.AreEqual(profileHeaderValue, profileObjectId.ToString());
        }
    }
}
