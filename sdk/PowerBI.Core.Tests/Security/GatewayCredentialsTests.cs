using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.PowerBI.Core.Cryptography;
using Microsoft.PowerBI.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Microsoft.PowerBI.Core.Tests.Security
{
    [TestClass]
    public class GatewayCredentialsTests
    {
        const string KeyContainerName = "GatewayCredentialsKeyContainerTest";

        [TestMethod]
        public void EncryptDecryptTest()
        {
            var containerName = "MyTestContainerName";

            var creds = new GatewayCredentials { Username = "foo", Password = "bar" };
            var cipherText = creds.Encrypt(KeyContainerName);
            var decrypted = GatewayCredentials.Decrypt(KeyContainerName, cipherText);

            Assert.AreEqual(creds.Username, decrypted.Username);
            Assert.AreEqual(creds.Password, decrypted.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DecryptWithMissingParams()
        {
            var credentialsContainer = new
            {
                credentialsData = new List<object>()
            };

            var json = JsonConvert.SerializeObject(credentialsContainer);
            var cipherText = AsymmetricKeyEncryptionHelper.Encrypt(json, KeyContainerName);

            GatewayCredentials.Decrypt(KeyContainerName, cipherText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DecryptWithInvalidShortCipherText()
        {
            var notReallyEncrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes("I'm just a short base64 string"));
            GatewayCredentials.Decrypt(KeyContainerName, notReallyEncrypted);
        }

        [TestMethod]
        [ExpectedException(typeof(CryptographicException))]
        public void DecryptWithInvalidCipherText()
        {
            var notReallyEncrypted = TestHelper.RandomString(256);
            GatewayCredentials.Decrypt(KeyContainerName, notReallyEncrypted);
        }
    }
}
