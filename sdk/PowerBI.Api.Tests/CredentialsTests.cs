using Microsoft.PowerBI.Api.Extensions.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.PowerBI.Api.V2.Models.Credentials;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicCredentials = Microsoft.PowerBI.Api.V2.Models.Credentials.BasicCredentials;

namespace PowerBI.Api.Tests
{
    [TestClass]
    public class CredentialsTests
    {
        private static readonly GatewayPublicKey publicKey = new GatewayPublicKey
        {
            Exponent = "AQAB",
            Modulus = "ut4A8JHd0x1LbA8AMLWK8+A1Xz1XRaMDFvCCo2TsIKyk4WIcR7D1tCtm6KBZO7XETdN8/fOkCP8DnxniYAC9aOfOtTNkLCWkf6arFJ/LfKs2XgcEHTIdrXKLDkOhuvQP83LiXrF7MFm/3HEb5NK53Ba53oxTuB36P+sHwU1wJMc="
        };

        [TestMethod]
        public void Cloud_BasicCredentialsTest()
        {
            CredentialsBase credentials = new BasicCredentials("user", "pass");
            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.None, EncryptedConnection.Encrypted);

            Assert.IsNotNull(credentialDetails);
            Assert.AreEqual("{\"credentialData\":[{\"name\":\"username\",\"value\":\"user\"},{\"name\":\"password\",\"value\":\"pass\"}]}", credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Basic, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.None, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.None, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void Cloud_WindowsCredentialsTest()
        {
            CredentialsBase credentials = new WindowsCredentials("user", "pass");
            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Organizational, EncryptedConnection.Encrypted);

            Assert.IsNotNull(credentialDetails);
            Assert.AreEqual("{\"credentialData\":[{\"name\":\"username\",\"value\":\"user\"},{\"name\":\"password\",\"value\":\"pass\"}]}", credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Windows, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.None, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Organizational, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void Cloud_KeyCredentialsTest()
        {
            CredentialsBase credentials = new KeyCredentials("TestKey");
            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Private, EncryptedConnection.Encrypted);

            Assert.IsNotNull(credentialDetails);
            Assert.AreEqual("{\"credentialData\":[{\"name\":\"key\",\"value\":\"TestKey\"}]}", credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Key, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.None, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Private, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void Cloud_OAuth2CredentialsTest()
        {
            CredentialsBase credentials = new OAuth2Credentials("TestToken");
            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Private, EncryptedConnection.Encrypted);

            Assert.IsNotNull(credentialDetails);
            Assert.AreEqual("{\"credentialData\":[{\"name\":\"accessToken\",\"value\":\"TestToken\"}]}", credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.OAuth2, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.None, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Private, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void Cloud_UsingCallerIdentityOAuth2CredentialsTest()
        {
            var credentialDetails = new CredentialDetailsUsingCallerOauthAADIdentity(PrivacyLevel.Private, EncryptedConnection.Encrypted);

            Assert.IsNotNull(credentialDetails);
            Assert.IsNull(credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.OAuth2, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.None, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Private, credentialDetails.PrivacyLevel);
            Assert.AreEqual(true, credentialDetails.UseCallerAADIdentity);
        }


        [TestMethod]
        public void Cloud_AnonymousCredentialsTest()
        {
            CredentialsBase credentials = new AnonymousCredentials();
            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Public, EncryptedConnection.NotEncrypted);

            Assert.IsNotNull(credentialDetails);
            Assert.AreEqual("{\"credentialData\":[]}", credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Anonymous, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.NotEncrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.None, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Public, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void OnPrem_BasicCredentialsTest()
        {
            CredentialsBase credentials = new BasicCredentials("user", "pass");
            var credentialsEncryptor = new AsymmetricKeyEncryptor(publicKey);

            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.None, EncryptedConnection.Encrypted, credentialsEncryptor);

            Assert.IsNotNull(credentialDetails);
            Assert.IsNotNull(credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Basic, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.RSAOAEP, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.None, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void OnPrem_WindowsCredentialsTest()
        {
            CredentialsBase credentials = new WindowsCredentials("user", "pass");
            var credentialsEncryptor = new AsymmetricKeyEncryptor(publicKey);

            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Organizational, EncryptedConnection.Encrypted, credentialsEncryptor);

            Assert.IsNotNull(credentialDetails);
            Assert.IsNotNull(credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Windows, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.RSAOAEP, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Organizational, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void OnPrem_KeyCredentialsTest()
        {
            CredentialsBase credentials = new KeyCredentials("TestKey");
            var credentialsEncryptor = new AsymmetricKeyEncryptor(publicKey);

            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Private, EncryptedConnection.Encrypted, credentialsEncryptor);

            Assert.IsNotNull(credentialDetails);
            Assert.IsNotNull(credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Key, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.RSAOAEP, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Private, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void OnPrem_OAuth2CredentialsTest()
        {
            CredentialsBase credentials = new OAuth2Credentials("TestToken");
            var credentialsEncryptor = new AsymmetricKeyEncryptor(publicKey);

            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Private, EncryptedConnection.Encrypted, credentialsEncryptor);

            Assert.IsNotNull(credentialDetails);
            Assert.IsNotNull(credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.OAuth2, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.Encrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.RSAOAEP, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Private, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }

        [TestMethod]
        public void OnPrem_AnonymousCredentialsTest()
        {
            CredentialsBase credentials = new AnonymousCredentials();
            var credentialsEncryptor = new AsymmetricKeyEncryptor(publicKey);

            var credentialDetails = new CredentialDetails(credentials, PrivacyLevel.Public, EncryptedConnection.NotEncrypted, credentialsEncryptor);

            Assert.IsNotNull(credentialDetails);
            Assert.IsNotNull(credentialDetails.Credentials);
            Assert.AreEqual(CredentialType.Anonymous, credentialDetails.CredentialType);
            Assert.AreEqual(EncryptedConnection.NotEncrypted, credentialDetails.EncryptedConnection);
            Assert.AreEqual(EncryptionAlgorithm.RSAOAEP, credentialDetails.EncryptionAlgorithm);
            Assert.AreEqual(PrivacyLevel.Public, credentialDetails.PrivacyLevel);
            Assert.AreEqual(false, credentialDetails.UseCallerAADIdentity);
        }
    }
}
