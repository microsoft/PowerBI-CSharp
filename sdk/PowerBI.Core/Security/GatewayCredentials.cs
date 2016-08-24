using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.PowerBI.Core.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.PowerBI.Core.Security
{
    /// <summary>
    /// The gateway credentials used to authticate to your datasources
    /// </summary>
    public class GatewayCredentials
    {
        /// <summary>
        /// The username used to authorize to the gateway
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The password used to authorize to the gateway
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Decryptes the specified credentials with a private key
        /// </summary>
        /// <param name="containerName">The container name</param>
        /// <param name="encryptedCredentials"></param>
        /// <returns></returns>
        public static GatewayCredentials Decrypt(string containerName, string encryptedCredentials)
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
                return new GatewayCredentials
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

        /// <summary>
        /// Encrypts the current instance
        /// </summary>
        /// <param name="containerName">The container name</param>
        /// <returns>Base64 encoded encrypted credientals</returns>
        public string Encrypt(string containerName)
        {
            Guard.ValidateString(containerName, nameof(containerName));

            if (string.IsNullOrWhiteSpace(this.Username) || string.IsNullOrWhiteSpace(this.Password))
            {
                throw new InvalidOperationException("Username and password must be set before encrypting the credentials");
            }

            var credentialsContainer = new
            {
                credentialsData = new List<object>
                {
                    new { name = "username", value = this.Username },
                    new { name = "password", value = this.Password }
                }
            };

            var json = JsonConvert.SerializeObject(credentialsContainer);
            return AsymmetricKeyEncryptionHelper.Encrypt(json, containerName);
        }
    }
}
