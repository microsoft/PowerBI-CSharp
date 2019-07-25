using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.PowerBI.Api.Extensions.V2.Models.Credentials
{
    public interface ICredentialsEncryptor
    {
        string EncodeCredentials(string plainText);
    }
}
