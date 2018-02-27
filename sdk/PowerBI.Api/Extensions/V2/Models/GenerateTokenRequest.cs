namespace Microsoft.PowerBI.Api.V2.Models
{
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
        public GenerateTokenRequest(string accessLevel, string datasetId, bool? allowSaveAs, EffectiveIdentity identity)
        {
            AccessLevel = accessLevel;
            DatasetId = datasetId;
            AllowSaveAs = allowSaveAs;
            Identities = new[] { identity };
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
        public GenerateTokenRequest(string accessLevel, bool? allowSaveAs, EffectiveIdentity identity)
        {
            AccessLevel = accessLevel;
            DatasetId = default(string);
            AllowSaveAs = allowSaveAs;
            Identities = new[] { identity };
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
        public GenerateTokenRequest(string accessLevel, string datasetId, EffectiveIdentity identity)
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
        public GenerateTokenRequest(string accessLevel, EffectiveIdentity identity)
        {
            AccessLevel = accessLevel;
            DatasetId = default(string);
            AllowSaveAs = null;
            Identities = new[] { identity };
            CustomInit();
        }
    }
}
