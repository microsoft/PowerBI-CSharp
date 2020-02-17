using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.PowerBI.Api.Extensions.Models.Credentials
{
    public interface ICredentialsEncryptor
    {
        string EncodeCredentials(string plainText);
    }
}
