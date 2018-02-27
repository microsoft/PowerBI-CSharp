namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Imports.
    /// </summary>
    public static partial class ImportsExtensions
    {
            /// <summary>
            /// Returns a list of imports for the specified group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            public static ODataResponseListImport GetImports(this IImports operations, string groupId)
            {
                return operations.GetImportsAsync(groupId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns a list of imports for the specified group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListImport> GetImportsAsync(this IImports operations, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetImportsInGroupWithHttpMessagesAsync(groupId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a new import using the specified import info
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetDisplayName'>
            /// The display name of the dataset
            /// </param>
            /// <param name='importInfo'>
            /// The import to post
            /// </param>
            /// <param name='nameConflict'>
            /// Determines what to do if a dataset with the same name already exists
            /// </param>
            public static Import PostImport(this IImports operations, string groupId, string datasetDisplayName, ImportInfo importInfo, string nameConflict = default(string))
            {
                return operations.PostImportAsync(groupId, datasetDisplayName, importInfo, nameConflict).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a new import using the specified import info
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetDisplayName'>
            /// The display name of the dataset
            /// </param>
            /// <param name='importInfo'>
            /// The import to post
            /// </param>
            /// <param name='nameConflict'>
            /// Determines what to do if a dataset with the same name already exists
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Import> PostImportAsync(this IImports operations, string groupId, string datasetDisplayName, ImportInfo importInfo, string nameConflict = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostImportInGroupWithHttpMessagesAsync(groupId, datasetDisplayName, importInfo, nameConflict, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the import metadata for the specifed import id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='importId'>
            /// The import id
            /// </param>
            public static Import GetImportById(this IImports operations, string groupId, string importId)
            {
                return operations.GetImportByIdAsync(groupId, importId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the import metadata for the specifed import id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='importId'>
            /// The import id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Import> GetImportByIdAsync(this IImports operations, string groupId, string importId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetImportByIdInGroupWithHttpMessagesAsync(groupId, importId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a temporary upload location for large files
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            public static TemporaryUploadLocation CreateTemporaryUploadLocation(this IImports operations, string groupId)
            {
                return operations.CreateTemporaryUploadLocationAsync(groupId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a temporary upload location for large files
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<TemporaryUploadLocation> CreateTemporaryUploadLocationAsync(this IImports operations, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateTemporaryUploadLocationInGroupWithHttpMessagesAsync(groupId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
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
        public static Import PostImportWithFile(this IImports operations, string groupId, Stream fileStream, string datasetDisplayName = default(string), string nameConflict = default(string))
        {
            return Task.Factory.StartNew(s => ((IImports)s).PostImportFileWithHttpMessage(groupId, fileStream, datasetDisplayName, nameConflict), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult().Body;
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
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Import> PostImportWithFileAsync(this IImports operations, string groupId, Stream fileStream, string datasetDisplayName = default(string), string nameConflict = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImportFileWithHttpMessage(groupId, fileStream, datasetDisplayName, nameConflict, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
