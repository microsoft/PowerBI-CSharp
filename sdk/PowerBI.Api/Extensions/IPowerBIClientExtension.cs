using System;

namespace Microsoft.PowerBI.Api
{
    /// <summary>
    /// Manual generated partial Interface IPowerBIClient for adding service principal profiles supporting methods
    /// </summary>
    public partial interface IPowerBIClient
    {
        /// <summary>
        /// Get service principal profile from client headers if exists
        /// </summary>
        /// <returns>Service principal profile ObjectId</returns>
        string GetServicePrincipalProfileObjectId();
    }
}
