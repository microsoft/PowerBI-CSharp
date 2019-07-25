namespace Microsoft.PowerBI.Api.V2.Models.Credentials
{
    using Microsoft.Rest;

    /// <summary>
    /// Username and Password based datasource credentials 
    /// </summary>
    public abstract class UsernamePasswordCredentials : CredentialsBase
    {
        private const string USERNAME = "username";
        private const string PASSWORD = "password";

        /// <summary>
        /// Initializes a new instance of the UsernamePasswordCredentials class.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        public UsernamePasswordCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, USERNAME);
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ValidationException(ValidationRules.CannotBeNull, PASSWORD);
            }

            this.CredentialData[USERNAME] = username;
            this.CredentialData[PASSWORD] = password;
        }
    }
}
