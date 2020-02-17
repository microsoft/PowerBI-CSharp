using Microsoft.PowerBI.Api.Extensions;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
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
        const string credentialData = "{\"credentialData\":[{\"name\":\"username\",\"value\":\"TestUser\"},{\"name\":\"password\",\"value\":\"TestPassword\"}]}";
        const string credentialDataLongInput = "{\"credentialData\":[{\"name\":\"username5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a\",\"value\":\"TestUser\"},{\"name\":\"password\",\"value\":\"TestPassword5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a5a7f3a19-6e75-4f53-be48-c9e8f8c95a4a\"}]}";
        const string Modulus1024bitKey = "ut4A8JHd0x1LbA8AMLWK8+A1Xz1XRaMDFvCCo2TsIKyk4WIcR7D1tCtm6KBZO7XETdN8/fOkCP8DnxniYAC9aOfOtTNkLCWkf6arFJ/LfKs2XgcEHTIdrXKLDkOhuvQP83LiXrF7MFm/3HEb5NK53Ba53oxTuB36P+sHwU1wJMc=";
        const string Modulus2048bitKey = "0YIEydh78Gq8OG1CH7fd0tvyof0hSmaCyfYRY102g82SJ284RNnNdlzcYCFaJSPUe2GEQGI0kB/Y57l/jATuVDOxYnq2s+NRcHYLPMIBaYaT9joAzXJ4+rHGK2Si+UWOFQXcik47EBQ+mMiC7touxkkrS2eAxtayTTwr+H+h7QrFnJyGw3gfVeysOuPVC5efAWrLPI2PoNzolMyhPmopaxWLK9IZBgP7MUQ7PcsDB3+Xgykc77fnCW2C5N49sIbhAv+JmU4XgMOF7Slekkp9Kl2XTLimE0TIyElO0sknIcKNtgGp5XFB7rfUqNQycfXvL6wwatw2ZlAVI5WoGnDqgQ==";
        const string Modulus4096bitKey = "zbjbh9Cku0edCOT+60KKdnM6rg5zcRu88RvdbSn5K1GF9r5ck1t7jwg2DXA9vNG3ivIwy3NrpEFSu+pOzqRWeOLVrAQ7bTW/X7CBdex2brUhZPAFo1sV8IbaFHld0aRK1SLWAsIWfjlRaRQuaHdf5H7WdqMgjS9xP78WNnG811ygZvVuaZb6hGvgfIXu5htnFYXB2VKD4WvMHJUQNYf04eOOq/JIAkn84qM3GJBe/TY+th3Xl7wG4+/MuN0MihoS8wcaPH3q0dUA9jfK//MdLNOu1CzlFsewUZF319ZHy2e5KG2a1xYWpCBfsnGx92DODuF4lPl3Cr8cXF8usy3GDnpBrMFFnTGipf+aJbr7PdBRc3Na4+rymlBdxip+K18KHRFsXWgrlOf9OrWVrz91EUoyypeugEagyGJidqUWYAm7O/BP9clPK2rJaEU+hT9IlMed+0n4+F7V8rT2rV+aaFJkTnp74arWcd0UgAMmf/ikay0FtbX1JOcQDP4QMlvz14QTiilJtgb8935WdNASmMC2aF9IyCZBnpLkimwpfcoCIFU8akv8bjyVDYziXgKP00seaHF2kFGRGpoxJAT20tN8SeKLyoIFgMJE8NJKE1T7CF6gTYssWjIPSJnJTFOnxyPFoTjqWndeMSExO32mFGoMKffTeb56h8UYaH02RNE=";

        [TestMethod]
        public void EncodeCredentialsTest_1024bitKey()
        {
            EncodeCredentialsTestImpl(credentialData, Exponent, Modulus1024bitKey);
        }

        [TestMethod]
        public void EncodeCredentialsTest_1024bitKey_LongInput()
        {
            EncodeCredentialsTestImpl(credentialDataLongInput, Exponent, Modulus1024bitKey);
        }

        [TestMethod]
        public void EncodeCredentialsTest_2048bitKey()
        {
            EncodeCredentialsTestImpl(credentialData, Exponent, Modulus2048bitKey);
        }

        [TestMethod]
        public void EncodeCredentialsTest_2048bitKey_LongInput()
        {
            EncodeCredentialsTestImpl(credentialData, Exponent, Modulus2048bitKey);
        }

        [TestMethod]
        public void EncodeCredentialsTest_4096bitKey()
        {
            EncodeCredentialsTestImpl(credentialData, Exponent, Modulus4096bitKey);
        }

        [TestMethod]
        public void EncodeCredentialsTest_4096bitKey_LongInput()
        {
            EncodeCredentialsTestImpl(credentialData, Exponent, Modulus4096bitKey);
        }

        private void EncodeCredentialsTestImpl(string credentialData, string exponent, string modulus)
        {
            var asymmetricKeyEncryptor = new AsymmetricKeyEncryptor(new GatewayPublicKey(exponent, modulus));
            var encodedCredentials = asymmetricKeyEncryptor.EncodeCredentials(credentialData);

            Assert.IsFalse(string.IsNullOrEmpty(encodedCredentials), "Encrypted credentials should not be null or empty");
        }

        [TestMethod]
        public void EncodeCredentials_BadCredentialsTest()
        {
            ValidateEncodeCredentialsException<ArgumentNullException>(null, Exponent, Modulus1024bitKey);
            ValidateEncodeCredentialsException<ArgumentNullException>(string.Empty, Exponent, Modulus1024bitKey);
        }

        [TestMethod]
        public void EncodeCredentials_BadPublicKeyTest()
        {
            const string credentialData = "{\"credentialData\":[{\"name\":\"username\",\"value\":\"TestUser\"},{\"name\":\"password\",\"value\":\"TestPassword\"}]}";

            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, null, Modulus1024bitKey);
            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, Exponent, null);

            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, string.Empty, Modulus1024bitKey);
            ValidateEncodeCredentialsException<ArgumentNullException>(credentialData, string.Empty, Modulus1024bitKey);

            ValidateEncodeCredentialsException<FormatException>(credentialData, "bad", Modulus1024bitKey);
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
