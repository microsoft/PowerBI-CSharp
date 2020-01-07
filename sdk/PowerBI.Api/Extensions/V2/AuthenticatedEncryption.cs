#if NETSTANDARD2_0
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Microsoft.PowerBI.Api.Extensions.V2
{    //Reference - https://docs.microsoft.com/en-us/dotnet/standard/security/vulnerabilities-cbc-mode
    public enum AeCipher : byte
    {
        Aes256CbcPkcs7
    }

    public enum AeMac : byte
    {
        HMACSHA256,
        HMACSHA384,
        HMACSHA512
    }

    /// <summary>
    /// Provides extension methods to make HashAlgorithm look like .NET Core's
    /// IncrementalHash
    /// </summary>
    internal static class IncrementalHashExtensions
    {
        public static void AppendData(this HashAlgorithm hash, byte[] data)
        {
            hash.TransformBlock(data, 0, data.Length, null, 0);
        }

        public static void AppendData(
            this HashAlgorithm hash,
            byte[] data,
            int offset,
            int length)
        {
            hash.TransformBlock(data, offset, length, null, 0);
        }

        public static byte[] GetHashAndReset(this HashAlgorithm hash)
        {
            hash.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
            return hash.Hash;
        }
    }

    public static partial class AuthenticatedEncryption
    {
        // choose an encryption scheme.
        private static AeCipher aeCipher = AeCipher.Aes256CbcPkcs7;

        // choose an authentication (message integrity) scheme.
        private static AeMac aeMac = AeMac.HMACSHA256;

        // It's good to be able to identify what choices were made when a message was
        // encrypted, so that the message can later be decrypted. This allows for
        // future versions to add support for new encryption schemes, but still be
        // able to read old data. A practice known as "cryptographic agility".
        //
        // This is similar in practice to PKCS#7 messaging, but this uses a
        // private-scoped byte rather than a public-scoped Object IDentifier (OID).
        private static byte[] algorithmChoices = { (byte)aeCipher, (byte)aeMac };

        public static byte[] Encrypt(byte[] keyEnc, byte[] keyMac, byte[] message)
        {
            if (keyEnc == null)
                throw new ArgumentNullException(nameof(keyEnc));
            if (keyMac == null)
                throw new ArgumentNullException(nameof(keyMac));
            if (keyEnc.Length < 32)
                throw new ArgumentOutOfRangeException(
                    nameof(keyEnc),
                    "Encryption Key must be at least 256 bits (32 bytes)");
            if (keyMac.Length < 32)
                throw new ArgumentOutOfRangeException(
                    nameof(keyMac),
                    "Mac Key must be at least 256 bits (32 bytes)");
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            byte[] iv;
            byte[] cipherText;
            byte[] tag;

            using (HMAC tagGenerator = GetMac(aeMac, keyMac))
            {
                using (SymmetricAlgorithm cipher = GetCipher(aeCipher, keyEnc))
                using (ICryptoTransform encryptor = cipher.CreateEncryptor())
                {
                    // Since no IV was provided, a random one has been generated
                    // during the call to CreateEncryptor.
                    //
                    // But note that it only does the auto-generation once. If the cipher
                    // object were used again, a call to GenerateIV would have been
                    // required.
                    iv = cipher.IV;

                    cipherText = Transform(encryptor, message, 0, message.Length);
                }

                // The IV and ciphertest both need to be included in the MAC to prevent
                // tampering.
                //
                // By including the algorithm identifiers, we have technically moved from
                // simple Authenticated Encryption (AE) to Authenticated Encryption with
                // Additional Data (AEAD). By including the algorithm identifiers in the
                // MAC, it becomes harder for an attacker to change them as an attempt to
                // perform a downgrade attack.

                byte[] tagData = new byte[algorithmChoices.Length + iv.Length + cipherText.Length];
                int tagDataOffset = 0;

                Append(algorithmChoices, tagData, ref tagDataOffset);
                Append(iv, tagData, ref tagDataOffset);
                Append(cipherText, tagData, ref tagDataOffset);

                tagGenerator.AppendData(tagData);
                tag = tagGenerator.GetHashAndReset();
            }

            // Build the final result as the concatenation of everything except the keys.
            int totalLength =
                algorithmChoices.Length +
                tag.Length +
                iv.Length +
                cipherText.Length;

            byte[] output = new byte[totalLength];
            int outputOffset = 0;

            Append(algorithmChoices, output, ref outputOffset);
            Append(tag, output, ref outputOffset);
            Append(iv, output, ref outputOffset);
            Append(cipherText, output, ref outputOffset);

            return output;
        }

        public static byte[] Decrypt(byte[] keyEnc, byte[] keyMac, byte[] cipherText)
        {
            if (keyEnc == null)
                throw new ArgumentNullException(nameof(keyEnc));
            if (keyMac == null)
                throw new ArgumentNullException(nameof(keyMac));
            if (keyEnc.Length < 32)
                throw new ArgumentOutOfRangeException(
                    nameof(keyEnc),
                    "Encryption Key must be at least 256 bits (32 bytes)");
            if (keyMac.Length < 32)
                throw new ArgumentOutOfRangeException(
                    nameof(keyMac),
                    "Mac Key must be at least 256 bits (32 bytes)");
            if (cipherText == null)
                throw new ArgumentNullException(nameof(cipherText));

            // The format of this message is assumed to be public, so there's no harm in
            // saying ahead of time that the message makes no sense.
            if (cipherText.Length < 2)
            {
                throw new CryptographicException();
            }

            // Use the message algorithm headers to determine what cipher algorithm and
            // MAC algorithm are going to be used. Since the same Key Derivation
            // Functions (KDFs) are being used in Decrypt as Encrypt, the keys are also
            // the same.
            AeCipher aeCipher = (AeCipher)cipherText[0];
            AeMac aeMac = (AeMac)cipherText[1];

            using (SymmetricAlgorithm cipher = GetCipher(aeCipher, keyEnc))
            using (HMAC tagGenerator = GetMac(aeMac, keyMac))
            {
                int blockSizeInBytes = cipher.BlockSize / 8;
                int tagSizeInBytes = tagGenerator.HashSize / 8;
                int headerSizeInBytes = 2;
                int tagOffset = headerSizeInBytes;
                int ivOffset = tagOffset + tagSizeInBytes;
                int cipherTextOffset = ivOffset + blockSizeInBytes;
                int cipherTextLength = cipherText.Length - cipherTextOffset;
                int minLen = cipherTextOffset + blockSizeInBytes;

                // Again, the minimum length is still assumed to be public knowledge,
                // nothing has leaked out yet. The minimum length couldn't just be calculated
                // without reading the header.
                if (cipherText.Length < minLen)
                {
                    throw new CryptographicException();
                }

                // It's very important that the MAC be calculated and verified before
                // proceeding to decrypt the ciphertext, as this prevents any sort of
                // information leaking out to an attacker.
                //
                // Don't include the tag in the calculation, though.
                var data = new byte[cipherText.Length - tagSizeInBytes];

                // First, everything before the tag (the cipher and MAC algorithm ids)
                Buffer.BlockCopy(cipherText, 0, data, 0, tagOffset);
                // Skip the data before the tag and the tag, then read everything that remains.
                Buffer.BlockCopy(cipherText, (tagOffset + tagSizeInBytes), data, tagOffset, cipherText.Length - (tagOffset + tagSizeInBytes));

                tagGenerator.AppendData(data);

                byte[] generatedTag = tagGenerator.GetHashAndReset();

                byte[] expectedPayload = new byte[tagSizeInBytes];
                Buffer.BlockCopy(cipherText, tagOffset, expectedPayload, 0, tagSizeInBytes);

                if (!CryptographicEquals(
                    generatedTag,
                    0,
                    cipherText,
                    tagOffset,
                    tagSizeInBytes))
                {
                    // Assuming every tampered message (of the same length) took the same
                    // amount of time to process, we can now safely say
                    // "this data makes no sense" without giving anything away.
                    throw new CryptographicException("Mismatch in signed data");
                }

                // Restore the IV into the symmetricAlgorithm instance.
                byte[] iv = new byte[blockSizeInBytes];
                Buffer.BlockCopy(cipherText, ivOffset, iv, 0, iv.Length);
                cipher.IV = iv;

                using (ICryptoTransform decryptor = cipher.CreateDecryptor())
                {
                    return Transform(
                        decryptor,
                        cipherText,
                        cipherTextOffset,
                        cipherTextLength);
                }
            }
        }

        private static byte[] Transform(
            ICryptoTransform transform,
            byte[] input,
            int inputOffset,
            int inputLength)
        {
            // Many of the implementations of ICryptoTransform report true for
            // CanTransformMultipleBlocks, and when the entire message is available in
            // one shot this saves on the allocation of the CryptoStream and the
            // intermediate structures it needs to properly chunk the message into blocks
            // (since the underlying stream won't always return the number of bytes
            // needed).
            if (transform.CanTransformMultipleBlocks)
            {
                return transform.TransformFinalBlock(input, inputOffset, inputLength);
            }

            // If our transform couldn't do multiple blocks at once, let CryptoStream
            // handle the chunking.
            using (MemoryStream messageStream = new MemoryStream())
            using (CryptoStream cryptoStream =
                new CryptoStream(messageStream, transform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(input, inputOffset, inputLength);
                cryptoStream.FlushFinalBlock();
                return messageStream.ToArray();
            }
        }

        /// <summary>
        /// Open a properly configured <see cref="SymmetricAlgorithm"/> conforming to the
        /// scheme identified by <paramref name="aeCipher"/>.
        /// </summary>
        /// <param name="aeCipher">The cipher mode to open.</param>
        /// <param name="keyEnc">The key data.</param>
        /// <returns>
        /// A SymmetricAlgorithm object with the right key, cipher mode, and padding
        /// mode; or <c>null</c> on unknown algorithms.
        /// </returns>
        private static SymmetricAlgorithm GetCipher(AeCipher aeCipher, byte[] keyEnc)
        {
            SymmetricAlgorithm symmetricAlgorithm;

            switch (aeCipher)
            {
                case AeCipher.Aes256CbcPkcs7:
                    symmetricAlgorithm = Aes.Create();
                    // While 256-bit, CBC, and PKCS7 are all the default values for these
                    // properties, being explicit helps comprehension more than it hurts
                    // performance.
                    symmetricAlgorithm.KeySize = 256;
                    symmetricAlgorithm.Mode = CipherMode.CBC;
                    symmetricAlgorithm.Padding = PaddingMode.PKCS7;
                    break;
                default:
                    // An algorithm we don't understand
                    throw new CryptographicException("Invalid Cipher algorithm");
            }

            symmetricAlgorithm.Key = keyEnc;
            return symmetricAlgorithm;
        }

        /// <summary>
        /// Open a properly configured <see cref="HMAC"/> conforming to the scheme
        /// identified by <paramref name="aeMac"/>.
        /// </summary>
        /// <param name="aeMac">The message authentication mode to open.</param>
        /// <param name="keyMac">The key data.</param>
        /// <returns>
        /// An HMAC object with the proper key, or <c>null</c> on unknown algorithms.
        /// </returns>
        private static HMAC GetMac(AeMac aeMac, byte[] keyMac)
        {
            HMAC hmac;

            switch (aeMac)
            {
                case AeMac.HMACSHA256:
                    hmac = new HMACSHA256();
                    break;
                case AeMac.HMACSHA384:
                    hmac = new HMACSHA384();
                    break;
                case AeMac.HMACSHA512:
                    hmac = new HMACSHA512();
                    break;
                default:
                    //An algorithm we don't understand
                    throw new CryptographicException("Invalid Mac algorithm");
            }
            hmac.Key = keyMac;
            return hmac;
        }

        // A simple helper method to ensure that the offset (writePos) always moves
        // forward with new data.
        private static void Append(byte[] newData, byte[] combinedData, ref int writePos)
        {
            Buffer.BlockCopy(newData, 0, combinedData, writePos, newData.Length);
            writePos += newData.Length;
        }

        /// <summary>
        /// Compare the contents of two arrays in an amount of time which is only
        /// dependent on <paramref name="length"/>.
        /// </summary>
        /// <param name="a">An array to compare to <paramref name="b"/>.</param>
        /// <param name="aOffset">
        /// The starting position within <paramref name="a"/> for comparison.
        /// </param>
        /// <param name="b">An array to compare to <paramref name="a"/>.</param>
        /// <param name="bOffset">
        /// The starting position within <paramref name="b"/> for comparison.
        /// </param>
        /// <param name="length">
        /// The number of bytes to compare between <paramref name="a"/> and
        /// <paramref name="b"/>.</param>
        /// <returns>
        /// <c>true</c> if both <paramref name="a"/> and <paramref name="b"/> have
        /// sufficient length for the comparison and all of the applicable values are the
        /// same in both arrays; <c>false</c> otherwise.
        /// </returns>
        /// <remarks>
        /// An "insufficient data" <c>false</c> response can happen early, but otherwise
        /// a <c>true</c> or <c>false</c> response take the same amount of time.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static bool CryptographicEquals(
            byte[] a,
            int aOffset,
            byte[] b,
            int bOffset,
            int length)
        {
            Debug.Assert(a != null);
            Debug.Assert(b != null);
            Debug.Assert(length >= 0);

            int result = 0;

            if (a.Length - aOffset < length || b.Length - bOffset < length)
            {
                return false;
            }

            unchecked
            {
                for (int i = 0; i < length; i++)
                {
                    // Bitwise-OR of subtraction has been found to have the most
                    // stable execution time.
                    //
                    // This cannot overflow because bytes are 1 byte in length, and
                    // result is 4 bytes.
                    // The OR propagates all set bytes, so the differences are only
                    // present in the lowest byte.
                    result = result | (a[i + aOffset] - b[i + bOffset]);
                }
            }

            return result == 0;
        }
    }
}

#endif
