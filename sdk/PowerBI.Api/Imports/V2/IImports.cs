using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;

namespace Microsoft.PowerBI.Api.V2
{
    /// <summary>
    /// Imports operations.
    /// </summary>
    public partial interface IImports
    {
        /// <summary>
        /// Uploads a PBIX file to the specified workspace
        /// </summary>
        /// <param name='file'>
        /// The PBIX file to import
        /// </param>
        /// <param name='datasetDisplayName'>
        /// The dataset display name
        /// </param>
        /// <param name='nameConflict'>
        /// Whether to overwrite dataset during conflicts
        /// </param>
        /// <param name="customHeaders">Optional custom headers</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        Task<HttpOperationResponse<Import>> PostImportFileWithHttpMessage(Stream file, string datasetDisplayName = default(string), string nameConflict = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
		
		/// <summary>
        /// Uploads a PBIX file to the specified group
        /// </summary>
        /// <param name='groupId'>
        /// The group Id
        /// </param>
        /// <param name='file'>
        /// The PBIX file to import
        /// </param>
        /// <param name='datasetDisplayName'>
        /// The dataset display name
        /// </param>
        /// <param name='nameConflict'>
        /// Whether to overwrite dataset during conflicts
        /// </param>
        /// <param name="customHeaders">
        /// Optional custom headers
        /// </param>
        /// <param name="cancellationToken">
        /// Optional cancellation token
        /// </param>
        Task<HttpOperationResponse<Import>> PostImportFileWithHttpMessage(string groupId, Stream file, string datasetDisplayName = default(string), string nameConflict = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
