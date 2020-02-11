namespace Microsoft.PowerBI.Api.Models.Credentials
{
    /// <summary>
    /// Username and Password based datasource credentials to be used in windows authentication
    /// </summary>
    public class WindowsCredentials : UsernamePasswordCredentials
    {
        internal override CredentialType CredentialType { get => CredentialType.Windows; }

        /// <summary>
        /// Initializes a new instance of the WindowsCredentials class.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        public WindowsCredentials(string username, string password) : base(username, password) { }
    }
}

