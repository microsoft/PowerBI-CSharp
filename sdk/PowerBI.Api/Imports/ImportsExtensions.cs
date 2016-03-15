using Microsoft.PowerBI.Api.Beta.Models;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.PowerBI.Api.Beta
{
    public static partial class ImportsExtensions
    {
        /// <summary>
        /// Creates a new import
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='datasetDisplayName'>
        /// </param>
        /// <param name='requestMessage'>
        /// </param>
        /// <param name='nameConflict'>
        /// </param>
        public static Import PostImportWithFile(this IImports operations, string collectionName, string workspaceId, Stream fileStream, string datasetDisplayName, int? nameConflict = default(int?))
        {
            return Task.Factory.StartNew(s => ((IImports)s).PostImportFileWithHttpMessage(collectionName, workspaceId, fileStream, datasetDisplayName, nameConflict), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult().Body;
        }

        /// <summary>
        /// Creates a new import
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='datasetDisplayName'>
        /// </param>
        /// <param name='requestMessage'>
        /// </param>
        /// <param name='nameConflict'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Import> PostImportWithFileAsync(this IImports operations, string collectionName, string workspaceId, Stream fileStream, string datasetDisplayName, int? nameConflict = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImportFileWithHttpMessage(collectionName, workspaceId, fileStream, datasetDisplayName, nameConflict, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
