﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;

namespace Microsoft.PowerBI.Api
{
    /// <summary>
    /// Imports operations.
    /// </summary>
    public partial interface IImportsOperations
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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        /// <param name='overrideReportLabel'>
        /// Determines whether to override existing label on report during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name='overrideModelLabel'>
        /// Determines whether to override existing label on model during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name="customHeaders">Optional custom headers</param>
        /// <param name="cancellationToken">Optional cancellation token</param>
        /// <returns></returns>
        Task<HttpOperationResponse<Import>> PostImportFileWithHttpMessage(Stream file, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), bool? overrideReportLabel = default(bool?), bool? overrideModelLabel = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

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
        /// <param name='skipReport'>
        /// Determines whether to skip report import, if specified value must be 'true'. Only supported for PBIX files.
        /// </param>
        /// <param name='overrideReportLabel'>
        /// Determines whether to override existing label on report during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name='overrideModelLabel'>
        /// Determines whether to override existing label on model during republish of PBIX file, service default value is true.
        /// </param>
        /// <param name="customHeaders">
        /// Optional custom headers
        /// </param>
        /// <param name="cancellationToken">
        /// Optional cancellation token
        /// </param>
        Task<HttpOperationResponse<Import>> PostImportFileWithHttpMessage(Guid? groupId, Stream file, string datasetDisplayName = default(string), ImportConflictHandlerMode? nameConflict = default(ImportConflictHandlerMode?), bool? skipReport = default(bool?), bool? overrideReportLabel = default(bool?), bool? overrideModelLabel = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
