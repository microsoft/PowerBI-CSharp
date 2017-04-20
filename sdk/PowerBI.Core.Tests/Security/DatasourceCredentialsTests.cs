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
    public class DatasourceCredentialsTests
    {
        const string KeyContainerName = "GatewayCredentialsKeyContainerTest";

        [TestMethod]
        public void EncryptWithKeyContainerTest()
        {
            var creds = new DatasourceCredentials { Username = "foo", Password = "bar" };
            var cipherText = CredentialsEncryption.Encrypt(new AsymmetricKey { KeyContainerName = KeyContainerName }, creds);
            var decrypted = CredentialsEncryption.Decrypt(KeyContainerName, cipherText);

            Assert.AreEqual(creds.Username, decrypted.Username);
            Assert.AreEqual(creds.Password, decrypted.Password);
        }

        [TestMethod]
        public void EncryptWithPublicKeyTest()
        {
            var key = AsymmetricKeyEncryptionHelper.ProduceAsymmetricKey(KeyContainerName);
            var publicKey = new AsymmetricKey { PublicKey = key.PublicKey };
            var creds = new DatasourceCredentials { Username = "foo", Password = "bar" };
            var cipherText = CredentialsEncryption.Encrypt(publicKey, creds);
            var decrypted = CredentialsEncryption.Decrypt(KeyContainerName, cipherText);

            Assert.AreEqual(creds.Username, decrypted.Username);
            Assert.AreEqual(creds.Password, decrypted.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncryptWithEmptyKey()
        {
            var creds = new DatasourceCredentials { Username = "foo", Password = "bar" };
            CredentialsEncryption.Encrypt(new AsymmetricKey(), creds);
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
            var cipherText = AsymmetricKeyEncryptionHelper.Encrypt(json, new AsymmetricKey { KeyContainerName = KeyContainerName });

            CredentialsEncryption.Decrypt(KeyContainerName, cipherText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DecryptWithInvalidShortCipherText()
        {
            var notReallyEncrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes("I'm just a short base64 string"));
            CredentialsEncryption.Decrypt(KeyContainerName, notReallyEncrypted);
        }

        [TestMethod]
        [ExpectedException(typeof(CryptographicException))]
        public void DecryptWithInvalidCipherText()
        {
            var notReallyEncrypted = TestHelper.RandomString(256);
            CredentialsEncryption.Decrypt(KeyContainerName, notReallyEncrypted);
        }
    }
}
