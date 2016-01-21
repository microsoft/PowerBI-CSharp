using Microsoft.PowerBI.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Microsoft.PowerBI.Core.Tests.Security
{
    [TestClass]
    public class TokenManagerTests
    {
        private TokenManager tokenManager;
        private IIdentity testIdentity;

        [TestInitialize]
        public void TestInitialize()
        {
            tokenManager = new TokenManager();
            testIdentity = new GenericIdentity("TestIdentity", "Test");
        }

        [TestMethod]
        public void ReadReturnsNullWhenNotFound()
        {
            var token = this.tokenManager.ReadToken(this.testIdentity);
            Assert.IsNull(token);
        }

        [TestMethod]
        public void CanAccessCurrentInstance()
        {
            var tokenManager = TokenManager.Current;
            Assert.IsNotNull(tokenManager);
        }

        [TestMethod]
        public void CanReadWriteTokenWithDefaultStrategy()
        {
            var expectedToken = "ABC123";
            this.tokenManager.WriteToken(this.testIdentity, expectedToken);
            var actualToken = this.tokenManager.ReadToken(this.testIdentity);

            Assert.AreEqual(expectedToken, actualToken);
        }

        [TestMethod]
        public void CanReadWriteTokenWithCustomStrategy()
        {
            var expectedToken = "DEF456";
            var store = new Dictionary<string, string>();

            this.tokenManager.SetTokenReader((identity) => store.ContainsKey(identity.Name) ? store[identity.Name] : null);
            this.tokenManager.SetTokenWriter((identity, accessToken) => store[identity.Name] = accessToken);

            this.tokenManager.WriteToken(this.testIdentity, expectedToken);
            Assert.AreEqual(expectedToken, store[this.testIdentity.Name]);

            var actualToken = this.tokenManager.ReadToken(this.testIdentity);
            Assert.AreEqual(expectedToken, actualToken);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadTokenThrowsArgumentNullWithNullIdentity()
        {
            this.tokenManager.ReadToken(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteTokenThrowsArgumentNullWithNullIdentity()
        {
            this.tokenManager.WriteToken(null, "abc");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteTokenThrowsArgumentNullWithNullAccessToken()
        {
            this.tokenManager.WriteToken(this.testIdentity, null);
        }
    }
}
