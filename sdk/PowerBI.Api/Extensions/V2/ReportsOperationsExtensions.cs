namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Reports.
    /// </summary>
    public static partial class ReportsOperationsExtensions
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
        public static Reports GetReports(this IReportsOperations operations, Guid groupId)
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
        public static async Task<Reports> GetReportsAsync(this IReportsOperations operations, Guid groupId, CancellationToken cancellationToken = default(CancellationToken))
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
        public static Reports GetReportsAsAdmin(this IReportsOperations operations, Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?))
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
        public static async Task<Reports> GetReportsAsAdminAsync(this IReportsOperations operations, Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?), CancellationToken cancellationToken = default(CancellationToken))
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        public static Report GetReport(this IReportsOperations operations, Guid groupId, Guid reportId)
        {
            return operations.GetReportAsync(groupId, reportId).GetAwaiter().GetResult();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Report> GetReportAsync(this IReportsOperations operations, Guid groupId, Guid reportId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetReportInGroupWithHttpMessagesAsync(groupId, reportId, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        public static void DeleteReport(this IReportsOperations operations, Guid groupId, Guid reportId)
        {
            operations.DeleteReportAsync(groupId, reportId).GetAwaiter().GetResult();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task DeleteReportAsync(this IReportsOperations operations, Guid groupId, Guid reportId, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.DeleteReportInGroupWithHttpMessagesAsync(groupId, reportId, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// Clone report parameters
        /// </param>
        public static Report CloneReport(this IReportsOperations operations, Guid groupId, Guid reportId, CloneReportRequest requestParameters)
        {
            return operations.CloneReportAsync(groupId, reportId, requestParameters).GetAwaiter().GetResult();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// Clone report parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Report> CloneReportAsync(this IReportsOperations operations, Guid groupId, Guid reportId, CloneReportRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CloneReportInGroupWithHttpMessagesAsync(groupId, reportId, requestParameters, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        public static Stream ExportReport(this IReportsOperations operations, Guid groupId, Guid reportId)
        {
            return operations.ExportReportAsync(groupId, reportId).GetAwaiter().GetResult();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Stream> ExportReportAsync(this IReportsOperations operations, Guid groupId, Guid reportId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var _result = await operations.ExportReportInGroupWithHttpMessagesAsync(groupId, reportId, null, cancellationToken).ConfigureAwait(false);
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// UpdateReportContent parameters
        /// </param>
        public static Report UpdateReportContent(this IReportsOperations operations, Guid groupId, Guid reportId, UpdateReportContentRequest requestParameters)
        {
            return operations.UpdateReportContentAsync(groupId, reportId, requestParameters).GetAwaiter().GetResult();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// UpdateReportContent parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Report> UpdateReportContentAsync(this IReportsOperations operations, Guid groupId, Guid reportId, UpdateReportContentRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.UpdateReportContentInGroupWithHttpMessagesAsync(groupId, reportId, requestParameters, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// Rebind report parameters
        /// </param>
        public static void RebindReport(this IReportsOperations operations, Guid groupId, Guid reportId, RebindReportRequest requestParameters)
        {
            operations.RebindReportAsync(groupId, reportId, requestParameters).GetAwaiter().GetResult();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// Rebind report parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task RebindReportAsync(this IReportsOperations operations, Guid groupId, Guid reportId, RebindReportRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.RebindReportInGroupWithHttpMessagesAsync(groupId, reportId, requestParameters, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        /// <summary>
        /// Returns a list of pages within the specified report from the specified workspace.
        /// </summary>
        /// <remarks>
        /// &lt;br/&gt;**Required scope**: Report.ReadWrite.All or Report.Read.All
        /// &lt;br/&gt;To set the permissions scope, see [Register an
        /// app](https://docs.microsoft.com/power-bi/developer/register-app).
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        /// <param name='reportId'>
        /// The report id
        /// </param>
        public static Pages GetPages(this IReportsOperations operations, System.Guid groupId, System.Guid reportId)
        {
            return operations.GetPagesAsync(groupId, reportId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns a list of pages within the specified report from the specified workspace.
        /// </summary>
        /// <remarks>
        /// &lt;br/&gt;**Required scope**: Report.ReadWrite.All or Report.Read.All
        /// &lt;br/&gt;To set the permissions scope, see [Register an
        /// app](https://docs.microsoft.com/power-bi/developer/register-app).
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Pages> GetPagesAsync(this IReportsOperations operations, System.Guid groupId, System.Guid reportId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetPagesInGroupWithHttpMessagesAsync(groupId, reportId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Returns the specified page within the specified report from the specified workspace.
        /// </summary>
        /// <remarks>
        /// &lt;br/&gt;**Required scope**: Report.ReadWrite.All or Report.Read.All
        /// &lt;br/&gt;To set the permissions scope, see [Register an
        /// app](https://docs.microsoft.com/power-bi/developer/register-app).
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='pageName'>
        /// The page name
        /// </param>
        public static Page GetPage(this IReportsOperations operations, System.Guid groupId, System.Guid reportId, string pageName)
        {
            return operations.GetPageAsync(groupId, reportId, pageName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns the specified page within the specified report from the specified workspace.
        /// </summary>
        /// <remarks>
        /// &lt;br/&gt;**Required scope**: Report.ReadWrite.All or Report.Read.All
        /// &lt;br/&gt;To set the permissions scope, see [Register an
        /// app](https://docs.microsoft.com/power-bi/developer/register-app).
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='pageName'>
        /// The page name
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Page> GetPageAsync(this IReportsOperations operations, System.Guid groupId, System.Guid reportId, string pageName, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetPageInGroupWithHttpMessagesAsync(groupId, reportId, pageName, null, cancellationToken).ConfigureAwait(false))
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
        public static EmbedToken GenerateTokenForCreate(this IReportsOperations operations, Guid groupId, GenerateTokenRequest requestParameters)
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
        public static async Task<EmbedToken> GenerateTokenForCreateAsync(this IReportsOperations operations, Guid groupId, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// Generate token parameters
        /// </param>
        public static EmbedToken GenerateToken(this IReportsOperations operations, Guid groupId, Guid reportId, GenerateTokenRequest requestParameters)
        {
            return operations.GenerateTokenAsync(groupId, reportId, requestParameters).GetAwaiter().GetResult();
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
        /// <param name='reportId'>
        /// The report id
        /// </param>
        /// <param name='requestParameters'>
        /// Generate token parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EmbedToken> GenerateTokenAsync(this IReportsOperations operations, Guid groupId, Guid reportId, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, reportId, requestParameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Returns a list of datasources for the specified RDL report from the
        /// specified workspace.
        /// </summary>
        /// <remarks>
        /// &lt;br/&gt;**Required scope**: Report.ReadWrite.All or Reportt.Read.All
        /// &lt;br/&gt;To set the permissions scope, see [Register an
        /// app](https://docs.microsoft.com/power-bi/developer/register-app).
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        /// <param name='reportId'>
        /// </param>
        public static Datasources GetDatasources(this IReportsOperations operations, System.Guid groupId, System.Guid reportId)
        {
            return operations.GetDatasourcesAsync(groupId, reportId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns a list of datasources for the specified RDL report from the
        /// specified workspace.
        /// </summary>
        /// <remarks>
        /// &lt;br/&gt;**Required scope**: Report.ReadWrite.All or Reportt.Read.All
        /// &lt;br/&gt;To set the permissions scope, see [Register an
        /// app](https://docs.microsoft.com/power-bi/developer/register-app).
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        /// <param name='reportId'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Datasources> GetDatasourcesAsync(this IReportsOperations operations, System.Guid groupId, System.Guid reportId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatasourcesInGroupWithHttpMessagesAsync(groupId, reportId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


    }
}
