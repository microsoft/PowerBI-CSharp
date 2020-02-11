namespace Microsoft.PowerBI.Api.Models.Credentials
{
    /// <summary>
    /// Username and Password based datasource credentials to be used in basic authentication
    /// </summary>
    public class BasicCredentials : UsernamePasswordCredentials
    {
        /// <summary>
        /// Initializes a new instance of the BasicCredentials class.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        public BasicCredentials(string username, string password) : base(username, password) { }

        internal override CredentialType CredentialType { get => CredentialType.Basic; }
    }
}
