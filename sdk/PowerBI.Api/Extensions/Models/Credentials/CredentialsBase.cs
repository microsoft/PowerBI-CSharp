namespace Microsoft.PowerBI.Api.Models.Credentials
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public abstract class CredentialsBase
    {
        internal abstract CredentialType CredentialType { get; }

        /// <summary>
        /// Initializes a new instance of the CredentialsBase class.
        /// </summary>
        public CredentialsBase()
        {
            this.CredentialData = new Dictionary<string, string>();
        }

        /// <summary>
        /// A dictionary to store the credential data
        /// </summary>
        public Dictionary<string, string> CredentialData { get; set; }
    }
}
