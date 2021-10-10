namespace Microsoft.PowerBI.Api.Models
{
    using System;

    /// <summary>
    /// Power BI Generate Token Request
    /// </summary>
    public partial class GenerateTokenRequest
    {
        /// <summary>
        /// Initializes a new instance of the GenerateTokenRequest class.
        /// </summary>
        /// <param name="accessLevel">The dataset mode or type. Possible values
        /// include: 'View', 'Edit', 'Create'</param>
        /// <param name="datasetId">The dataset Id</param>
        /// <param name="allowSaveAs">Allow SaveAs the report with generated
        /// token.</param>
        /// <param name="identity">The effective identity to use for RLS
        /// rules</param>
        /// <param name="lifetimeInMinutes">The maximum lifetime of the token
        /// in minutes, starting from the time it was generated. Can be used to
        /// shorten the token’s expiration time, but not to extend it. The
        /// value must be a positive integer. Zero (0) is equivalent to null
        /// and will be ignored, resulting in the default expiration
        /// time.</param>
        public GenerateTokenRequest(TokenAccessLevel accessLevel, string datasetId, bool? allowSaveAs, EffectiveIdentity identity, int? lifetimeInMinutes = default(int?))
        {
            AccessLevel = accessLevel;
            DatasetId = datasetId;
            AllowSaveAs = allowSaveAs;
            Identities = new[] { identity };
            LifetimeInMinutes = lifetimeInMinutes;
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GenerateTokenRequest class.
        /// </summary>
        /// <param name="accessLevel">The dataset mode or type. Possible values
        /// include: 'View', 'Edit', 'Create'</param>
        /// <param name="allowSaveAs">Allow SaveAs the report with generated
        /// token.</param>
        /// <param name="identity">The effective identity to use for RLS
        /// rules</param>
        /// <param name="lifetimeInMinutes">The maximum lifetime of the token
        /// in minutes, starting from the time it was generated. Can be used to
        /// shorten the token’s expiration time, but not to extend it. The
        /// value must be a positive integer. Zero (0) is equivalent to null
        /// and will be ignored, resulting in the default expiration
        /// time.</param>
        public GenerateTokenRequest(TokenAccessLevel accessLevel, bool? allowSaveAs, EffectiveIdentity identity, int? lifetimeInMinutes = default(int?))
        {
            AccessLevel = accessLevel;
            DatasetId = null;
            AllowSaveAs = allowSaveAs;
            Identities = new[] { identity };
            LifetimeInMinutes = lifetimeInMinutes;
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GenerateTokenRequest class.
        /// </summary>
        /// <param name="accessLevel">The dataset mode or type. Possible values
        /// include: 'View', 'Edit', 'Create'</param>
        /// <param name="datasetId">The dataset Id</param>
        /// <param name="identity">The effective identity to use for RLS
        /// rules</param>
        public GenerateTokenRequest(TokenAccessLevel accessLevel, string datasetId, EffectiveIdentity identity)
        {
            AccessLevel = accessLevel;
            DatasetId = datasetId;
            AllowSaveAs = null;
            Identities = new[] { identity };
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GenerateTokenRequest class.
        /// </summary>
        /// <param name="accessLevel">The dataset mode or type. Possible values
        /// include: 'View', 'Edit', 'Create'</param>
        /// <param name="identity">The effective identity to use for RLS
        /// rules</param>
        public GenerateTokenRequest(TokenAccessLevel accessLevel, EffectiveIdentity identity)
        {
            AccessLevel = accessLevel;
            DatasetId = null;
            AllowSaveAs = null;
            Identities = new[] { identity };
            CustomInit();
        }
    }
}
