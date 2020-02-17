using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.Models;

namespace Microsoft.PowerBI.Api
{
    public static partial class ImportsOperationsExtensions
    {
        /// <summary>
        /// Uploads a PBIX file to the specified group
        /// </summary>
        /// <param name="operations">
        /// The import operations
        /// </param>
        /// <param name='groupId'>
        /// The group id
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        public static Import PostImportWithFileInGroup(this IImportsOperations operations, Guid groupId, Stream fileStream, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?))
        {
            return Task.Factory.StartNew(s => ((IImportsOperations)s).PostImportFileWithHttpMessage(groupId, fileStream, datasetDisplayName, nameConflict), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult().Body;
        }

        /// <summary>
        /// Uploads a PBIX file to the specified group
        /// </summary>
        /// <param name="operations">
        /// The import operations
        /// </param>
        /// <param name='groupId'>
        /// The group id
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Import> PostImportWithFileAsyncInGroup(this IImportsOperations operations, Guid groupId, Stream fileStream, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImportFileWithHttpMessage(groupId, fileStream, datasetDisplayName, nameConflict, skipReport, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Uploads a PBIX file to MyWorkspace
        /// </summary>
        /// <param name="operations">
        /// The import operations
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        public static Import PostImportWithFile(this IImportsOperations operations, Stream fileStream, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?))
        {
            return Task.Factory.StartNew(s => ((IImportsOperations)s).PostImportFileWithHttpMessage(fileStream, datasetDisplayName, nameConflict, skipReport), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult().Body;
        }

        /// <summary>
        /// Uploads a PBIX file to the specified group
        /// </summary>
        /// <param name="operations">
        /// The import operations
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Import> PostImportWithFileAsync(this IImportsOperations operations, Stream fileStream, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImportFileWithHttpMessage(fileStream, datasetDisplayName, nameConflict, skipReport, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
