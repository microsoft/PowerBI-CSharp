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
        /// <param name="identities">The effective identities to use for RLS
        /// rules</param>
        public GenerateTokenRequest(string accessLevel = default(string), string datasetId = default(string), bool? allowSaveAs = default(bool?), EffectiveIdentity identity = default(EffectiveIdentity))
        {
            AccessLevel = accessLevel;
            DatasetId = datasetId;
            AllowSaveAs = allowSaveAs;
            Identities = new[] { identity };
            CustomInit();
        }
    }
}
