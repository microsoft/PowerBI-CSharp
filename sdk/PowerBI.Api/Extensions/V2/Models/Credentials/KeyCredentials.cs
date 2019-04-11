namespace Microsoft.PowerBI.Api.V2.Models.Credentials
{
    using Microsoft.Rest;

    /// <summary>
    /// Key based datasource credentials 
    /// </summary>
    public class KeyCredentials : CredentialsBase
    {
        private const string KEY = "key";

        internal override CredentialType CredentialType { get => CredentialType.Key; }

        /// <summary>
        /// Initializes a new instance of the KeyCredentials class.
        /// </summary>
        /// <param name="key">The key</param>
        public KeyCredentials(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, KEY);
            }

            this.CredentialData[KEY] = key;
        }
    }
}
