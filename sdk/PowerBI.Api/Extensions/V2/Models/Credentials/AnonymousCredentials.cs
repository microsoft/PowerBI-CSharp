namespace Microsoft.PowerBI.Api.V2.Models.Credentials
{
    /// <summary>
    /// Anonymous datasource credentials
    /// </summary>
    public class AnonymousCredentials : CredentialsBase
    {
        internal override CredentialType CredentialType { get => CredentialType.Anonymous; }
    }
}
