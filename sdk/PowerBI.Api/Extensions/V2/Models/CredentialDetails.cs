namespace Microsoft.PowerBI.Api.V2.Models
{
    using Microsoft.PowerBI.Api.Extensions.V2.Models.Credentials;
    using Microsoft.PowerBI.Api.V2.Models.Credentials;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The credential details
    /// </summary>
    public partial class CredentialDetails
    {
        /// <summary>
        /// Initializes a new instance of the CredentialDetails class.
        /// </summary>
        public CredentialDetails(CredentialsBase credentialsBase, PrivacyLevel privacyLevel, EncryptedConnection encryptedConnection, ICredentialsEncryptor credentialsEncryptor = null)
            : this(privacyLevel, encryptedConnection, credentialsEncryptor)
        {
            var credentials = new CredentialsRequest
            {
                CredentialData = credentialsBase.CredentialData.Select((pair) => new NameValuePair(pair.Key, pair.Value))
            };

            var credentialsJson = JsonConvert.SerializeObject(credentials);

            if (credentialsEncryptor != null)
            {
                credentialsJson = credentialsEncryptor.EncodeCredentials(credentialsJson);
            }

            Credentials = credentialsJson;
            CredentialType = credentialsBase.CredentialType;
        }

        /// <summary>
        /// Initializes a new instance of the CredentialDetails class.
        /// </summary>
        protected CredentialDetails(PrivacyLevel privacyLevel, EncryptedConnection encryptedConnection, ICredentialsEncryptor credentialsEncryptor)
        {
            EncryptedConnection = encryptedConnection;
            EncryptionAlgorithm = credentialsEncryptor != null ? EncryptionAlgorithm.RSAOAEP : EncryptionAlgorithm.None;
            PrivacyLevel = privacyLevel;
            UseCallerAADIdentity = false;
            CustomInit();
        }
    }

    /// <summary>
    /// The credential details using caller AAD identity as OAuth credentials
    /// </summary>
    public class CredentialDetailsUsingCallerOauthAADIdentity : CredentialDetails
    {
        /// <summary>
        /// Initializes a new instance of the UpdateDatasourceRequest class for cloud datasource.
        /// </summary>
        public CredentialDetailsUsingCallerOauthAADIdentity(PrivacyLevel privacyLevel, EncryptedConnection encryptedConnection)
            : base(privacyLevel, encryptedConnection, null)
        {
            CredentialType = CredentialType.OAuth2;
            UseCallerAADIdentity = true;
        }
    }

    /// <summary>
    /// CredentialsRequest
    /// </summary>
    public class CredentialsRequest
    {
        [JsonProperty(PropertyName = "credentialData")]
        public IEnumerable<NameValuePair> CredentialData { get; set; }
    }

    /// <summary>
    /// NameValuePair
    /// </summary>
    public class NameValuePair
    {
        public NameValuePair() { }

        public NameValuePair(string name = default(string), string value = default(string))
        {
            this.Name = name;
            this.Value = value;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
