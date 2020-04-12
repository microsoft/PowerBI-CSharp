using System;
using System.Security.Cryptography;
using System.Threading;

namespace Microsoft.PowerBI.Api.Extensions
{
    public static class Asymmetric1024KeyEncryptionHelper
    {
        private const int SegmentLength = 85;
        private const int EncryptedLength = 128;
        private const int maxAttempts = 3;

        internal static string Encrypt(byte[] plainTextBytes, byte[] modulusBytes, byte[] exponentBytes)
        {
            // Split the message into different segments, each segment's length is 85. So the result may be 85,85,85,20.
            var hasIncompleteSegment = plainTextBytes.Length % SegmentLength != 0;

            var segmentNumber = (!hasIncompleteSegment) ? (plainTextBytes.Length / SegmentLength) : ((plainTextBytes.Length / SegmentLength) + 1);

            var encryptedBytes = new byte[segmentNumber * EncryptedLength];

            for (var i = 0; i < segmentNumber; i++)
            {
                int lengthToCopy;

                if (i == segmentNumber - 1 && hasIncompleteSegment)
                {
                    lengthToCopy = plainTextBytes.Length % SegmentLength;
                }
                else
                {
                    lengthToCopy = SegmentLength;
                }

                var segment = new byte[lengthToCopy];

                Array.Copy(plainTextBytes, i * SegmentLength, segment, 0, lengthToCopy);

                var segmentEncryptedResult = EncryptSegment(modulusBytes, exponentBytes, segment);

                for (var j = 0; j < segmentEncryptedResult.Length; j++)
                {
                    encryptedBytes[(i * EncryptedLength) + j] = segmentEncryptedResult[j];
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        private static byte[] EncryptSegment(byte[] modulus, byte[] exponent, byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (data.Length == 0)
            {
                return data;
            }

            for (var attempt = 0; attempt < maxAttempts; ++attempt)
            {
                try
                {
                    using (var rsa = new RSACryptoServiceProvider())
                    {
                        var rsaKeyInfo = rsa.ExportParameters(false);

                        rsaKeyInfo.Modulus = modulus;
                        rsaKeyInfo.Exponent = exponent;
                        rsa.ImportParameters(rsaKeyInfo);
                        var encryptedBytes = rsa.Encrypt(data, true);
                        return encryptedBytes;
                    }
                }
                catch (CryptographicException)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(50));
                    if (attempt == maxAttempts - 1)
                    {
                        throw;
                    }
                }
            }

            throw new InvalidOperationException();
        }
    }
}