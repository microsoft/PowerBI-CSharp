using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.V1.Models;

namespace Microsoft.PowerBI.Api.V1
{
    public static partial class ImportsExtensions
    {
        /// <summary>
        /// Uploads a PBIX file to the specified workspace
        /// </summary>
        /// <param name="operations">
        /// The import operations
        /// </param>
        /// <param name='collectionName'>
        /// The workspace collection name
        /// </param>
        /// <param name='workspaceId'>
        /// The workspace id
        /// </param>
        /// <param name='fileStream'>
        /// The PBIX file to import
        /// </param>
        /// <param name='datasetDisplayName'>
        /// The dataset display name
        /// </param>
        /// <param name='nameConflict'>
        /// Whether to overwrite dataset during conflicts
        /// </param>
        public static Import PostImportWithFile(this IImports operations, string collectionName, string workspaceId, Stream fileStream, string datasetDisplayName = default(string), string nameConflict = default(string))
        {
            return Task.Factory.StartNew(s => ((IImports)s).PostImportFileWithHttpMessage(collectionName, workspaceId, fileStream, datasetDisplayName, nameConflict), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult().Body;
        }

        /// <summary>
        /// Uploads a PBIX file to the specified workspace
        /// </summary>
        /// <param name="operations">
        /// The import operations
        /// </param>

        /// <param name='collectionName'>
        /// The workspace collection name
        /// </param>
        /// <param name='workspaceId'>
        /// The workspace id
        /// </param>
        /// <param name='fileStream'>
        /// The PBIX file to import
        /// </param>
        /// <param name='datasetDisplayName'>
        /// The dataset display name
        /// </param>
        /// <param name='nameConflict'>
        /// Whether to overwrite dataset during conflicts
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Import> PostImportWithFileAsync(this IImports operations, string collectionName, string workspaceId, Stream fileStream, string datasetDisplayName = default(string), string nameConflict = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImportFileWithHttpMessage(collectionName, workspaceId, fileStream, datasetDisplayName, nameConflict, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
