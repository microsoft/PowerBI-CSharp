using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.PowerBI.Core.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.PowerBI.Core.Tests.Cryptography
{
    [TestClass]
    public class AsymmetricKeyEncryptionHelperTests
    {
        const string KeyContainerName = "PBISDKCryptographyTest";

        [TestMethod]
        public void ProduceAsymmetricKeyTest()
        {
            var asymmetricKey = AsymmetricKeyEncryptionHelper.ProduceAsymmetricKey(KeyContainerName);

            Assert.IsNotNull(asymmetricKey);
            Assert.AreEqual(KeyContainerName, asymmetricKey.KeyContainerName);
            Assert.IsNotNull(asymmetricKey.PublicKey);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ProduceAsymmetricKeyTestWithNullContainerFails()
        {
            AsymmetricKeyEncryptionHelper.ProduceAsymmetricKey(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProduceAsymmetricKeyTestWithEmptyStringContainerFails()
        {
            AsymmetricKeyEncryptionHelper.ProduceAsymmetricKey(string.Empty);
        }

        [TestMethod]
        public void EncryptWithKeyContainer()
        {
            var plainText = "i am the string to encrypt";

            var cipherText = AsymmetricKeyEncryptionHelper.Encrypt(plainText, new AsymmetricKey { KeyContainerName = KeyContainerName });
            var decryptedText = AsymmetricKeyEncryptionHelper.Decrypt(cipherText, KeyContainerName);

            Assert.AreEqual(plainText, decryptedText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EncryptWithInvalidPublicKey()
        {
            var plainText = "i am the string to encrypt";
            var publicKey = new AsymmetricKey { PublicKey = TestHelper.RandomString(256) };

            AsymmetricKeyEncryptionHelper.Encrypt(plainText, publicKey);
        }

        [TestMethod]
        public void EncryptWithPublicKey()
        {
            var plainText = "i am the string to encrypt";
            var key = AsymmetricKeyEncryptionHelper.ProduceAsymmetricKey(KeyContainerName);
            var publicKey = new AsymmetricKey { PublicKey = key.PublicKey };

            var cipherText = AsymmetricKeyEncryptionHelper.Encrypt(plainText, publicKey);
            var decryptedText = AsymmetricKeyEncryptionHelper.Decrypt(cipherText, KeyContainerName);

            Assert.AreEqual(plainText, decryptedText);
        }

        [TestMethod]
        [ExpectedException(typeof(CryptographicException))]
        public void EncryptDecryptStringWithDifferenetContainerName()
        {
            var plainText = "i am the string to encrypt";

            var cipherText = AsymmetricKeyEncryptionHelper.Encrypt(plainText, new AsymmetricKey { KeyContainerName = KeyContainerName });
            var decryptedText = AsymmetricKeyEncryptionHelper.Decrypt(cipherText, KeyContainerName + "Bad");

            Assert.AreEqual(plainText, decryptedText);
        }

        [TestMethod]
        [ExpectedException(typeof(CryptographicException))]
        public void DecryptUnencryptedString()
        {
            var randomString = TestHelper.RandomString(256);
            AsymmetricKeyEncryptionHelper.Decrypt(randomString, KeyContainerName);
        }
    }
}
