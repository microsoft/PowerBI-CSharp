using System;
using System.Security.Cryptography;

namespace Microsoft.PowerBI.Api.Extensions
{
    using System.Security.Cryptography;
    public enum KeyLengths : byte
    {
        KeyLength32,
        KeyLength64
    }

    public static class AsymmetricHigherKeyEncryptionHelper
    {
        private static int KEY_LENGTHS_PREFIX = 2;
        private static int MIN_HMAC_KEY_SIZE_BYTES = 32;
        private static int HMAC_KEY_SIZE_BYTES = 64;
        private static int AES_KEY_SIZE_BYTES = 32;

        internal static string Encrypt(byte[] plainTextBytes, byte[] modulusBytes, byte[] exponentBytes)
        {
            // Generate ephemeral keys for encryption (32 bytes), hmac (64 bytes)
            var keyEnc = GetRandomBytes(AES_KEY_SIZE_BYTES);
            var keyMac = GetRandomBytes(HMAC_KEY_SIZE_BYTES);

            // Encrypt message using ephemeral keys and Authenticated Encryption
            var ciphertext = AuthenticatedEncryption.Encrypt(keyEnc, keyMac, plainTextBytes);

            // Encrypt ephemeral keys using RSA
            var keys = new byte[KEY_LENGTHS_PREFIX + keyEnc.Length + keyMac.Length];

            // Prefixing length of Keys. Symmetric Key length followed by HMAC key length
            keys[0] = (byte)KeyLengths.KeyLength32;
            keys[1] = (byte)KeyLengths.KeyLength64;

            Buffer.BlockCopy(keyEnc, 0, keys, 2, keyEnc.Length);
            Buffer.BlockCopy(keyMac, 0, keys, keyEnc.Length + 2, keyMac.Length);
            byte[] encryptedKeys;

            using (var rsa = new RSACng())
            {
                var rsaKeyInfo = rsa.ExportParameters(false);
                rsaKeyInfo.Modulus = modulusBytes;
                rsaKeyInfo.Exponent = exponentBytes;
                rsa.ImportParameters(rsaKeyInfo);
                encryptedKeys = rsa.Encrypt(keys, RSAEncryptionPadding.OaepSHA256);
            }

            // prepare final payload
            return Convert.ToBase64String(encryptedKeys) + Convert.ToBase64String(ciphertext);
        }

        private static byte[] GetRandomBytes(int size)
        {
            var data = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(data);
            }
            return data;
        }
    }
}