using Microsoft.PowerBI.Api.Extensions.V2;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace PowerBI.Api.Tests
{
    [TestClass]
    public class AsymmetricKeyEncryptorTests
    {
        const string Exponent = "AQAB";
        const string Modulus = "ut4A8JHd0x1LbA8AMLWK8+A1Xz1XRaMDFvCCo2TsIKyk4WIcR7D1tCtm6KBZO7XETdN8/fOkCP8DnxniYAC9aOfOtTNkLCWkf6arFJ/LfKs2XgcEHTIdrXKLDkOhuvQP83LiXrF7MFm/3HEb5NK53Ba53oxTuB36P+sHwU1wJMc=";

        [TestMethod]
        public void EncodeCredentialsTest()
        {
            const string credentialData = "{\"credentialData\":[{\"name\":\"username\",\"value\":\"TestUser\"},{\"name\":\"password\",\"value\":\"TestPassword\"}]}";

            var asymmetricKeyEncryptor = new AsymmetricKeyEncryptor(new GatewayPublicKey(Exponent, Modulus));
            var encodedCredentials = asymmetricKeyEncryptor.EncodeCredentials(credentialData);

            Assert.IsFalse(string.IsNullOrEmpty(encodedCredentials), "Encrypted credentials should not be null or empty");
        }

        [TestMethod]
        public void EncodeCredentials_BadCredentialsTest()
        {
            ValidateEncodeCredentialsException<ArgumentNullException>(null, Exponent, Modulus);
            ValidateEncodeCredentialsException<ArgumentNullException>(string.Empty, Exponent, Modulus);
        }

        [TestMethod]
        public void EncodeCredentials_BadPublicKeyTest()
        {
            const string credentialData = "{\"credentialData\":[{\"name\":\"username\",\"value\":\"TestUser\"},{\"name\":\"password\",\"value\":\"TestPassword\"}]}";

            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, null, Modulus);
            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, Exponent, null);

            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, string.Empty, Modulus);
            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, string.Empty, Modulus);

            ValidateEncodeCredentialsException<FormatException>(credentialData, "bad", Modulus);
            ValidateEncodeCredentialsException<FormatException>(credentialData, Exponent, "bad");
        }

        private void ValidateEncodeCredentialsException<T>(string credentialData, string exponent, string modulus) where T : Exception
        {
            try
            {
                var asymmetricKeyEncryptor = new AsymmetricKeyEncryptor(new GatewayPublicKey(exponent, modulus));
                asymmetricKeyEncryptor.EncodeCredentials(credentialData);
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex as T, "expected exception to be of Type {0}, instead got {1}", typeof(T).Name, ex.GetType().Name);
                return;
            }

            Assert.Fail("exception of Type {0} should be thrown", typeof(T).Name);
        }
    }
}
