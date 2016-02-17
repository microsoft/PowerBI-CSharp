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
        public static object PostImportWithFile(this IImports operations, Stream fileStream, string datasetDisplayName, int? nameConflict = default(int?))
        {
            return Task.Factory.StartNew(s => ((IImports)s).PostImporFileWithHttpMessage(fileStream, datasetDisplayName, nameConflict), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
        public static async Task<object> PostImportWithFileAsync(this IImports operations, Stream fileStream, string datasetDisplayName, int? nameConflict = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImporFileWithHttpMessage(fileStream, datasetDisplayName, nameConflict, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
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
        public static object PostImportByGroupWithFile(this IImports operations, string group, Stream fileStream, string datasetDisplayName, int? nameConflict = default(int?))
        {
            return Task.Factory.StartNew(s => ((IImports)s).PostImporFileByGroupWithHttpMessage(group, fileStream, datasetDisplayName, nameConflict), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
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
        public static async Task<object> PostImporByGrouptWithFileAsync(this IImports operations, string group, Stream fileStream, string datasetDisplayName, int? nameConflict = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImporFileByGroupWithHttpMessage(group, fileStream, datasetDisplayName, nameConflict, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
