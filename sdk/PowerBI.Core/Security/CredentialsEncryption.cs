using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.PowerBI.Core.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.PowerBI.Core.Security
{
    /// <summary>
    /// Encrypts and decripts datasource credentials
    /// </summary>
    public static class CredentialsEncryption
    {
        /// <summary>
        /// Encryptes the datasource credentials using hte keys from the specifiec container name
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="credentials">The datasource credentials to encrypt</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string Encrypt(AsymmetricKey key, DatasourceCredentials credentials)
        {
            Guard.ValidateObjectNotNull(key, nameof(key));
            Guard.ValidateObjectNotNull(credentials, nameof(credentials));

            if (string.IsNullOrWhiteSpace(credentials.Username) || string.IsNullOrWhiteSpace(credentials.Password))
            {
                throw new InvalidOperationException("Username and password must be set before encrypting the credentials");
            }

            var credentialsContainer = new
            {
                credentialsData = new List<object>
                {
                    new { name = "username", value = credentials.Username },
                    new { name = "password", value = credentials.Password }
                }
            };

            var json = JsonConvert.SerializeObject(credentialsContainer);
            return AsymmetricKeyEncryptionHelper.Encrypt(json, key);
        }

        /// <summary>
        /// Decrypts the datasource credentials using the keys from the specified container name
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="encryptedCredentials"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static DatasourceCredentials Decrypt(string containerName, string encryptedCredentials)
        {
            Guard.ValidateString(containerName, nameof(containerName));
            Guard.ValidateString(encryptedCredentials, nameof(encryptedCredentials));

            var json = AsymmetricKeyEncryptionHelper.Decrypt(encryptedCredentials, containerName);
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Unable to decrypt the credentials", nameof(encryptedCredentials));
            }

            var credentialsContainer = JsonConvert.DeserializeObject<JObject>(json);
            var credentials = (JArray)credentialsContainer["credentialsData"];

            try
            {
                return new DatasourceCredentials
                {
                    Username = GetCredentialPartValue(credentials, "username"),
                    Password = GetCredentialPartValue(credentials, "password")
                };
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException("Username and/or password not found in the credentials", ex);
            }

        }

        private static string GetCredentialPartValue(JArray credentialParts, string name)
        {
            var part = credentialParts.FirstOrDefault(p => p["name"]?.Value<string>() == name);
            if (part == null)
            {
                throw new ArgumentOutOfRangeException(nameof(name), $"{name} not found within credentials");
            }

            return part["value"]?.Value<string>();
        }
    }
}
