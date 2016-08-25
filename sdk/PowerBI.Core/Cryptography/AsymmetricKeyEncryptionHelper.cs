using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.PowerBI.Core.Cryptography
{
    /// <summary>
    /// Helper class for encrypting and decrypting with asymmetric keys
    /// </summary>
    public static class AsymmetricKeyEncryptionHelper
    {
        private const int SegmentLength = 85;
        private const int EncryptedLength = 128;

        /// <summary>
        /// Creates a new asymmetric key within the specified key container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static AsymmetricKey ProduceAsymmetricKey(string containerName)
        {
            Guard.ValidateString(containerName, nameof(containerName));

            var cspParams = new CspParameters { KeyContainerName = containerName };

            // delete any old keys associated with the existing container
            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                rsa.PersistKeyInCsp = false;
                rsa.Clear();
            }

            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                // The public key will be saved in PBI service when gateway register
                // The private key will ONLY be stored on the GW machine
                // We don't directly handle private key, but we do retrieve the public key as part of the step
                var publicKey = rsa.ExportParameters(false);

                return new AsymmetricKey
                {
                    KeyContainerName = containerName,
                    PublicKey = ConvertKeyToString(publicKey),
                };
            }
        }

        /// <summary>
        /// Encrypts the text from the keys in the specified container
        /// </summary>
        /// <param name="plainText">The text to encrypt</param>
        /// <param name="key">The key information</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Encrypt(string plainText, AsymmetricKey key)
        {
            Guard.ValidateString(plainText, nameof(plainText));
            Guard.ValidateObjectNotNull(key, nameof(key));

            if (string.IsNullOrWhiteSpace(key.KeyContainerName) && string.IsNullOrWhiteSpace(key.PublicKey))
            {
                throw new ArgumentException("KeyContainerName or PublicKey must be set");
            }

            var plainTextArray = Encoding.UTF8.GetBytes(plainText);

            // Split the message into different segments, each segment's length is 85. So the result may be 85,85,85,20.
            var hasIncompleteSegment = plainTextArray.Length % SegmentLength != 0;

            var segmentNumber = (!hasIncompleteSegment) ? (plainTextArray.Length / SegmentLength) : ((plainTextArray.Length / SegmentLength) + 1);

            var encryptedData = new byte[segmentNumber * EncryptedLength];

            for (var i = 0; i < segmentNumber; i++)
            {
                var lengthToCopy = 0;

                if (i == segmentNumber - 1 && hasIncompleteSegment)
                {
                    lengthToCopy = plainTextArray.Length % SegmentLength;
                }
                else
                {
                    lengthToCopy = SegmentLength;
                }

                var segment = new byte[lengthToCopy];

                Array.Copy(plainTextArray, i * SegmentLength, segment, 0, lengthToCopy);

                var segmentEncryptedResult = string.IsNullOrWhiteSpace(key.KeyContainerName)
                    ? EncryptWithPublicKey(ConvertStringToKey(key.PublicKey), segment)
                    : EncryptWithContainer(key.KeyContainerName, segment);

                for (var j = 0; j < segmentEncryptedResult.Length; j++)
                {
                    encryptedData[(i * EncryptedLength) + j] = segmentEncryptedResult[j];
                }
            }
            return Convert.ToBase64String(encryptedData);
        }

        /// <summary>
        /// Decrypted the cipher text with the keys in the specified container 
        /// </summary>
        /// <param name="ciphertext">The cipher text to decrypt</param>
        /// <param name="containerName">The key container name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Decrypt(string cipherText, string containerName)
        {
            Guard.ValidateString(cipherText, nameof(cipherText));
            Guard.ValidateString(containerName, nameof(containerName));

            var ciphertextArray = Convert.FromBase64String(cipherText);

            var length = ciphertextArray.Length / EncryptedLength;
            var result = new List<byte>();

            for (var i = 0; i < length; i++)
            {
                var segment = new byte[EncryptedLength];
                Array.Copy(ciphertextArray, i * EncryptedLength, segment, 0, EncryptedLength);

                var segmentDecryptedResult = Decrypt(containerName, segment);
                result.AddRange(segmentDecryptedResult);
            }
            return Encoding.UTF8.GetString(result.ToArray(), 0, result.Count);
        }

        private static byte[] EncryptWithContainer(string containerName, byte[] data)
        {
            Guard.ValidateString(containerName, nameof(containerName));
            Guard.ValidateObjectNotNull(data, nameof(data));

            if (data.Length == 0) return data;

            var cspParams = new CspParameters { KeyContainerName = containerName };

            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                return rsa.Encrypt(data, true);
            }
        }

        private static byte[] EncryptWithPublicKey(RSAParameters publicKey, byte[] data)
        {
            if (Equals(publicKey, default(RSAParameters)))
            {
                throw new ArgumentNullException(nameof(publicKey));
            }

            Guard.ValidateObjectNotNull(data, nameof(data));

            if (data.Length == 0) return data;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);
                return rsa.Encrypt(data, true);
            }
        }

        private static byte[] Decrypt(string containerName, byte[] data)
        {
            Guard.ValidateString(containerName, nameof(containerName));
            Guard.ValidateObjectNotNull(data, nameof(data));

            if (data.Length == 0)
            {
                return data;
            }

            var cspParams = new CspParameters { KeyContainerName = containerName };

            using (var rsa = new RSACryptoServiceProvider(cspParams))
            {
                var decryptedBytes = rsa.Decrypt(data, true);
                return decryptedBytes;
            }
        }

        private static string ConvertKeyToString(RSAParameters key)
        {
            var xml = new XmlSerializer(typeof(RSAParameters));
            using (var stream = new MemoryStream())
            {
                xml.Serialize(stream, key);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        private static RSAParameters ConvertStringToKey(string publicKey)
        {
            var xml = new XmlSerializer(typeof(RSAParameters));
            var bytes = Convert.FromBase64String(publicKey);
            using (var stream = new MemoryStream(bytes))
            {
                try
                {
                    return (RSAParameters)xml.Deserialize(stream);
                }
                catch (InvalidOperationException ex)
                {
                    throw new ArgumentException("Argument is not a valid RSA public key", nameof(publicKey), ex);
                }
            }
        }
    }
}
