namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Reports.
    /// </summary>
    public static partial class ReportsExtensions
    {
            /// <summary>
            /// Gets a list of reports available within the specified group
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            public static ODataResponseListReport GetReports(this IReports operations, string groupId)
            {
                return operations.GetReportsAsync(groupId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of reports available within the specified group
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
            public static async Task<ODataResponseListReport> GetReportsAsync(this IReports operations, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetReportsInGroupWithHttpMessagesAsync(groupId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns a list of reports from the specified workspace for an organization
            /// with an administrative scope.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;**Required scope**: Tenant.Read.All or
            /// Tenant.ReadWrite.All&lt;br/&gt;Application only and delegated permissions
            /// are supported.&lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='filter'>
            /// Filters the results, based on a boolean condition
            /// </param>
            /// <param name='top'>
            /// Returns only the first n results
            /// </param>
            /// <param name='skip'>
            /// Skips the first n results
            /// </param>
            public static ODataResponseListReport GetReportsAsAdmin(this IReports operations, string groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?))
            {
                return operations.GetReportsInGroupAsAdminAsync(groupId, filter, top, skip).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns a list of reports from the specified workspace for an organization
            /// with an administrative scope.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;**Required scope**: Tenant.Read.All or
            /// Tenant.ReadWrite.All&lt;br/&gt;Application only and delegated permissions
            /// are supported.&lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='filter'>
            /// Filters the results, based on a boolean condition
            /// </param>
            /// <param name='top'>
            /// Returns only the first n results
            /// </param>
            /// <param name='skip'>
            /// Skips the first n results
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListReport> GetReportsAsAdminAsync(this IReports operations, string groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetReportsInGroupAsAdminWithHttpMessagesAsync(groupId, filter, top, skip, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            public static Report GetReport(this IReports operations, string groupId, string reportKey)
            {
                return operations.GetReportAsync(groupId, reportKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Report> GetReportAsync(this IReports operations, string groupId, string reportKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetReportInGroupWithHttpMessagesAsync(groupId, reportKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            public static object DeleteReport(this IReports operations, string groupId, string reportKey)
            {
                return operations.DeleteReportAsync(groupId, reportKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> DeleteReportAsync(this IReports operations, string groupId, string reportKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteReportInGroupWithHttpMessagesAsync(groupId, reportKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Clones the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// Clone report parameters
            /// </param>
            public static Report CloneReport(this IReports operations, string groupId, string reportKey, CloneReportRequest requestParameters)
            {
                return operations.CloneReportAsync(groupId, reportKey, requestParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Clones the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// Clone report parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Report> CloneReportAsync(this IReports operations, string groupId, string reportKey, CloneReportRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CloneReportInGroupWithHttpMessagesAsync(groupId, reportKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Exports the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            public static Stream ExportReport(this IReports operations, string groupId, string reportKey)
            {
                return operations.ExportReportAsync(groupId, reportKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Exports the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Stream> ExportReportAsync(this IReports operations, string groupId, string reportKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                var _result = await operations.ExportReportInGroupWithHttpMessagesAsync(groupId, reportKey, null, cancellationToken).ConfigureAwait(false);
                _result.Request.Dispose();
                return _result.Body;
            }

            /// <summary>
            /// Update the report content from a specified source
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// UpdateReportContent parameters
            /// </param>
            public static Report UpdateReportContent(this IReports operations, string groupId, string reportKey, UpdateReportContentRequest requestParameters)
            {
                return operations.UpdateReportContentAsync(groupId, reportKey, requestParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update the report content from a specified source
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// UpdateReportContent parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Report> UpdateReportContentAsync(this IReports operations, string groupId, string reportKey, UpdateReportContentRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateReportContentInGroupWithHttpMessagesAsync(groupId, reportKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Rebinds the specified report to requested dataset id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// Rebind report parameters
            /// </param>
            public static object RebindReport(this IReports operations, string groupId, string reportKey, RebindReportRequest requestParameters)
            {
                return operations.RebindReportAsync(groupId, reportKey, requestParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Rebinds the specified report to requested dataset id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// Rebind report parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> RebindReportAsync(this IReports operations, string groupId, string reportKey, RebindReportRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RebindReportInGroupWithHttpMessagesAsync(groupId, reportKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Generate token to create a new report on a given dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            public static EmbedToken GenerateTokenForCreate(this IReports operations, string groupId, GenerateTokenRequest requestParameters)
            {
                return operations.GenerateTokenForCreateAsync(groupId, requestParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Generate token to create a new report on a given dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EmbedToken> GenerateTokenForCreateAsync(this IReports operations, string groupId, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GenerateTokenForCreateInGroupWithHttpMessagesAsync(groupId, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Generate token to view or edit the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            public static EmbedToken GenerateToken(this IReports operations, string groupId, string reportKey, GenerateTokenRequest requestParameters)
            {
                return operations.GenerateTokenAsync(groupId, reportKey, requestParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Generate token to view or edit the specified report
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='reportKey'>
            /// The report id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EmbedToken> GenerateTokenAsync(this IReports operations, string groupId, string reportKey, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, reportKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
