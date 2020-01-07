#if NETSTANDARD2_0

using Microsoft.PowerBI.Api.Extensions.V2.Models.Credentials;
using Microsoft.PowerBI.Api.V2.Models;
using System;
using System.Text;

namespace Microsoft.PowerBI.Api.Extensions.V2
{
    public class AsymmetricKeyEncryptor : ICredentialsEncryptor
    {
        private const int DefaultRSAKeySize = 1024;
        private readonly GatewayPublicKey publicKey;

        public AsymmetricKeyEncryptor(GatewayPublicKey publicKey)
        {
            if (publicKey == null)
            {
                throw new ArgumentNullException("publicKey");
            }

            if (string.IsNullOrEmpty(publicKey.Exponent))
            {
                throw new ArgumentNullException("publicKey.Exponent");
            }

            if (string.IsNullOrEmpty(publicKey.Modulus))
            {
                throw new ArgumentNullException("publicKey.Modulus");
            }

            this.publicKey = publicKey;
        }

        /// <summary>
        /// Encrypts credentials using RSA algorithm
        /// </summary>
        public string EncodeCredentials(string credentialData)
        {
            if (string.IsNullOrEmpty(credentialData))
            {
                throw new ArgumentNullException("credentialData");
            }

            var plainTextBytes = Encoding.UTF8.GetBytes(credentialData);
            var modulusBytes = Convert.FromBase64String(this.publicKey.Modulus);
            var exponentBytes = Convert.FromBase64String(this.publicKey.Exponent);

                return modulusBytes.Length == 128
                ? Asymmetric1024KeyEncryptionHelper.Encrypt(plainTextBytes, modulusBytes, exponentBytes)
                : AsymmetricHigherKeyEncryptionHelper.Encrypt(plainTextBytes, modulusBytes, exponentBytes);
        }
    }
}

#endif
