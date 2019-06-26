namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Dataflows.
    /// </summary>
    public static partial class DataflowsOperationsExtensions
    {
        /// <summary>
        /// Returns a list of dataflows for the organization.
        /// </summary>
        /// <remarks>
        /// **Note:** The user must have administrator rights (such as Office 365
        /// Global Administrator or Power BI Service Administrator) to call this API.
        /// &lt;br/&gt;&lt;br/&gt;**Required scope**: Tenant.Read.All or
        /// Tenant.ReadWrite.All&lt;br/&gt;To set the permissions scope, see [Register
        /// an app](https://docs.microsoft.com/power-bi/developer/register-app).
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
        public static Dataflows GetDataflowsAsAdmin(this IDataflowsOperations operations, System.Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?))
        {
            return operations.GetDataflowsInGroupAsAdminAsync(groupId, filter, top, skip).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns a list of dataflows for the organization.
        /// </summary>
        /// <remarks>
        /// **Note:** The user must have administrator rights (such as Office 365
        /// Global Administrator or Power BI Service Administrator) to call this API.
        /// &lt;br/&gt;&lt;br/&gt;**Required scope**: Tenant.Read.All or
        /// Tenant.ReadWrite.All&lt;br/&gt;To set the permissions scope, see [Register
        /// an app](https://docs.microsoft.com/power-bi/developer/register-app).
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
        public static async Task<Dataflows> GetDataflowsAsAdminAsync(this IDataflowsOperations operations, System.Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDataflowsInGroupAsAdminWithHttpMessagesAsync(groupId, filter, top, skip, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
