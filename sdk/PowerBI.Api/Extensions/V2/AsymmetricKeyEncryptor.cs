#if NETSTANDARD2_0

namespace Microsoft.PowerBI.Api.Extensions.V2
{
    using Microsoft.PowerBI.Api.Extensions.V2.Models.Credentials;
    using Microsoft.PowerBI.Api.V2.Models;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class AsymmetricKeyEncryptor : ICredentialsEncryptor
    {
        private const int SegmentLength = 85;
        private const int EncryptedLength = 128;

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

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(EncryptedLength * 8))
            {
                var parameters = rsa.ExportParameters(false);
                parameters.Exponent = Convert.FromBase64String(publicKey.Exponent);
                parameters.Modulus = Convert.FromBase64String(publicKey.Modulus);
                rsa.ImportParameters(parameters);
                return Encrypt(credentialData, rsa);
            }
        }

        private static string Encrypt(string plainText, RSACryptoServiceProvider rsa)
        {
            byte[] plainTextArray = Encoding.UTF8.GetBytes(plainText);

            // Split the message into different segments, each segment's length is 85. So the result may be 85,85,85,20.
            bool hasIncompleteSegment = plainTextArray.Length % SegmentLength != 0;

            int segmentNumber = (!hasIncompleteSegment) ? (plainTextArray.Length / SegmentLength) : ((plainTextArray.Length / SegmentLength) + 1);

            byte[] encryptedData = new byte[segmentNumber * EncryptedLength];
            int encryptedDataPosition = 0;

            for (var i = 0; i < segmentNumber; i++)
            {
                int lengthToCopy;

                if (i == segmentNumber - 1 && hasIncompleteSegment)
                    lengthToCopy = plainTextArray.Length % SegmentLength;
                else
                    lengthToCopy = SegmentLength;

                var segment = new byte[lengthToCopy];

                Array.Copy(plainTextArray, i * SegmentLength, segment, 0, lengthToCopy);

                var segmentEncryptedResult = rsa.Encrypt(segment, true);

                Array.Copy(segmentEncryptedResult, 0, encryptedData, encryptedDataPosition, segmentEncryptedResult.Length);

                encryptedDataPosition += segmentEncryptedResult.Length;
            }

            return Convert.ToBase64String(encryptedData);
        }
    }
}

#endif
