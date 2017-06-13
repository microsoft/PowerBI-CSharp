using System;

namespace Microsoft.PowerBI.Api.V2
{
    partial interface IPowerBIClient
    {
        PowerBIError GetError(Exception exception);
    }
}