namespace Microsoft.PowerBI.Api
{
    using Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Dashboards.
    /// </summary>
    public static partial class DashboardsOperationsExtensions
    {
        /// <summary>
        /// Gets a list of dashboards in a group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        public static Dashboards GetDashboards(this IDashboardsOperations operations, Guid groupId)
        {
            return operations.GetDashboardsAsync(groupId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a list of dashboards in a group
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
        public static async Task<Dashboards> GetDashboardsAsync(this IDashboardsOperations operations, Guid groupId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDashboardsInGroupWithHttpMessagesAsync(groupId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Add a new empty dashboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='requestParameters'>
        /// Add dashboard parameters
        /// </param>
        public static Dashboard AddDashboard(this IDashboardsOperations operations, Guid groupId, AddDashboardRequest requestParameters)
        {
            return operations.AddDashboardAsync(groupId, requestParameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Add a new empty dashboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='requestParameters'>
        /// Add dashboard parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Dashboard> AddDashboardAsync(this IDashboardsOperations operations, Guid groupId, AddDashboardRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.AddDashboardInGroupWithHttpMessagesAsync(groupId, requestParameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get the specified dashboard in a group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        public static Dashboard GetDashboard(this IDashboardsOperations operations, Guid groupId, Guid dashboardId)
        {
            return operations.GetDashboardAsync(groupId, dashboardId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get the specified dashboard in a group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Dashboard> GetDashboardAsync(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDashboardInGroupWithHttpMessagesAsync(groupId, dashboardId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Deletes the specified dashboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        public static void DeleteDashboard(this IDashboardsOperations operations, Guid groupId, Guid dashboardId)
        {
            operations.DeleteDashboardAsync(groupId, dashboardId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes the specified dashboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task DeleteDashboardAsync(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.DeleteDashboardInGroupWithHttpMessagesAsync(groupId, dashboardId, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        /// <summary>
        /// Returns a list of dashboards from the specified workspace for an
        /// organization with an administrative scope.
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
        public static AdminDashboards GetDashboardsAsAdmin(this IDashboardsOperations operations, Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?))
        {
            return operations.GetDashboardsInGroupAsAdminAsync(groupId, filter, top, skip).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns a list of dashboards from the specified workspace for an
        /// organization with an administrative scope.
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
        public static async Task<AdminDashboards> GetDashboardsAsAdminAsync(this IDashboardsOperations operations, Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDashboardsInGroupAsAdminWithHttpMessagesAsync(groupId, filter, top, skip, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get tiles in the specified dashboard in a group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        public static Tiles GetTiles(this IDashboardsOperations operations, Guid groupId, Guid dashboardId)
        {
            return operations.GetTilesAsync(groupId, dashboardId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get tiles in the specified dashboard in a group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Tiles> GetTilesAsync(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetTilesInGroupWithHttpMessagesAsync(groupId, dashboardId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a specified tile in a specified dashboard in a group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='tileId'>
        /// The tile id
        /// </param>
        public static Tile GetTile(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, Guid tileId)
        {
            return operations.GetTileAsync(groupId, dashboardId, tileId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a specified tile in a specified dashboard in a group
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='tileId'>
        /// The tile id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Tile> GetTileAsync(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, Guid tileId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetTileInGroupWithHttpMessagesAsync(groupId, dashboardId, tileId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Clones the specified tile
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='tileId'>
        /// The tile id
        /// </param>
        /// <param name='requestParameters'>
        /// Clone tile parameters
        /// </param>
        public static Tile CloneTile(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, Guid tileId, CloneTileRequest requestParameters)
        {
            return operations.CloneTileAsync(groupId, dashboardId, tileId, requestParameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Clones the specified tile
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='tileId'>
        /// The tile id
        /// </param>
        /// <param name='requestParameters'>
        /// Clone tile parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Tile> CloneTileAsync(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, Guid tileId, CloneTileRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.CloneTileInGroupWithHttpMessagesAsync(groupId, dashboardId, tileId, requestParameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Generate token to view the specified dashboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='requestParameters'>
        /// Generate token parameters
        /// </param>
        public static EmbedToken GenerateToken(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, GenerateTokenRequest requestParameters)
        {
            return operations.GenerateTokenAsync(groupId, dashboardId, requestParameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generate token to view the specified dashboard
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='dashboardId'>
        /// The dashboard id
        /// </param>
        /// <param name='requestParameters'>
        /// Generate token parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EmbedToken> GenerateTokenAsync(this IDashboardsOperations operations, Guid groupId, Guid dashboardId, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, dashboardId, requestParameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
