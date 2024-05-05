namespace Microsoft.PowerBI.Api
{
    using Models;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Imports.
    /// </summary>
    public static partial class ImportsOperationsExtensions
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
        public static Imports GetImports(this IImportsOperations operations, Guid groupId)
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
        public static async Task<Imports> GetImportsAsync(this IImportsOperations operations, Guid groupId, CancellationToken cancellationToken = default(CancellationToken))
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        /// <param name='overrideReportLabel'>
        /// Determines whether to override existing label on report during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name='overrideModelLabel'>
        /// Determines whether to override existing label on model during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name="subfolderObjectId">
        /// The subfolder ID to import the file to subfolder.
        /// </param>
        public static Import PostImport(this IImportsOperations operations, Guid groupId, string datasetDisplayName, ImportInfo importInfo, ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), bool? overrideReportLabel = default(bool?), bool? overrideModelLabel = default(bool?), Guid? subfolderObjectId = default(Guid?))
        {
            return operations.PostImportAsync(groupId, datasetDisplayName, importInfo, nameConflict, skipReport, overrideReportLabel, overrideModelLabel, subfolderObjectId).GetAwaiter().GetResult();
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        /// <param name='overrideReportLabel'>
        /// Determines whether to override existing label on report during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name='overrideModelLabel'>
        /// Determines whether to override existing label on model during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name="subfolderObjectId">
        /// The subfolder ID to import the file to subfolder.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Import> PostImportAsync(this IImportsOperations operations, Guid groupId, string datasetDisplayName, ImportInfo importInfo, ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), bool? overrideReportLabel = default(bool?), bool? overrideModelLabel = default(bool?), Guid? subfolderObjectId = default(Guid?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImportInGroupWithHttpMessagesAsync(groupId, datasetDisplayName, importInfo, nameConflict, skipReport, overrideReportLabel, overrideModelLabel, subfolderObjectId, null, cancellationToken).ConfigureAwait(false))
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
        public static Import GetImport(this IImportsOperations operations, Guid groupId, Guid importId)
        {
            return operations.GetImportAsync(groupId, importId).GetAwaiter().GetResult();
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
        public static async Task<Import> GetImportAsync(this IImportsOperations operations, Guid groupId, Guid importId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetImportInGroupWithHttpMessagesAsync(groupId, importId, null, cancellationToken).ConfigureAwait(false))
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
        public static TemporaryUploadLocation CreateTemporaryUploadLocation(this IImportsOperations operations, Guid groupId)
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
        public static async Task<TemporaryUploadLocation> CreateTemporaryUploadLocationAsync(this IImportsOperations operations, Guid groupId, CancellationToken cancellationToken = default(CancellationToken))
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        /// <param name='overrideReportLabel'>
        /// Determines whether to override existing label on report during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name='overrideModelLabel'>
        /// Determines whether to override existing label on model during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name="subfolderObjectId">
        /// The subfolder ID to import the file to subfolder.
        /// </param>
        public static Import PostImportWithFile(this IImportsOperations operations, Guid groupId, Stream fileStream, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), bool? overrideReportLabel = default(bool?), bool? overrideModelLabel = default(bool?), Guid? subfolderObjectId = default(Guid?))
        {
            return Task.Factory.StartNew(s => ((IImportsOperations)s).PostImportFileWithHttpMessage(groupId, fileStream, datasetDisplayName, nameConflict, skipReport, overrideReportLabel, overrideModelLabel, subfolderObjectId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult().Body;
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
        /// <param name='overrideReportLabel'>
        /// Determines whether to override existing label on report during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name='overrideModelLabel'>
        /// Determines whether to override existing label on model during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name="subfolderObjectId">
        /// The subfolder ID to import the file to subfolder.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Import> PostImportWithFileAsync(this IImportsOperations operations, Guid groupId, Stream fileStream, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), bool? overrideReportLabel = default(bool?), bool? overrideModelLabel = default(bool?), Guid? subfolderObjectId = default(Guid?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostImportFileWithHttpMessage(groupId, fileStream, datasetDisplayName, nameConflict, skipReport, overrideReportLabel, overrideModelLabel, subfolderObjectId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
