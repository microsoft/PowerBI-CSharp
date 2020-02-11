namespace Microsoft.PowerBI.Api.Models.Credentials
{
    /// <summary>
    /// Anonymous datasource credentials
    /// </summary>
    public class AnonymousCredentials : CredentialsBase
    {
        internal override CredentialType CredentialType { get => CredentialType.Anonymous; }
    }
}
