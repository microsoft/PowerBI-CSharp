namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Dashboards.
    /// </summary>
    public static partial class DashboardsExtensions
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
            public static ODataResponseListDashboard GetDashboards(this IDashboards operations, string groupId)
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
            public static async Task<ODataResponseListDashboard> GetDashboardsAsync(this IDashboards operations, string groupId, CancellationToken cancellationToken = default(CancellationToken))
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
            public static Dashboard AddDashboard(this IDashboards operations, string groupId, AddDashboardRequest requestParameters)
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
            public static async Task<Dashboard> AddDashboardAsync(this IDashboards operations, string groupId, AddDashboardRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            public static Dashboard GetDashboard(this IDashboards operations, string groupId, string dashboardKey)
            {
                return operations.GetDashboardAsync(groupId, dashboardKey).GetAwaiter().GetResult();
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Dashboard> GetDashboardAsync(this IDashboards operations, string groupId, string dashboardKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetDashboardInGroupWithHttpMessagesAsync(groupId, dashboardKey, null, cancellationToken).ConfigureAwait(false))
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            public static ODataResponseListTile GetTiles(this IDashboards operations, string groupId, string dashboardKey)
            {
                return operations.GetTilesAsync(groupId, dashboardKey).GetAwaiter().GetResult();
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListTile> GetTilesAsync(this IDashboards operations, string groupId, string dashboardKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetTilesInGroupWithHttpMessagesAsync(groupId, dashboardKey, null, cancellationToken).ConfigureAwait(false))
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='tileKey'>
            /// The tile id
            /// </param>
            public static Tile GetTile(this IDashboards operations, string groupId, string dashboardKey, string tileKey)
            {
                return operations.GetTileAsync(groupId, dashboardKey, tileKey).GetAwaiter().GetResult();
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='tileKey'>
            /// The tile id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Tile> GetTileAsync(this IDashboards operations, string groupId, string dashboardKey, string tileKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetTileInGroupWithHttpMessagesAsync(groupId, dashboardKey, tileKey, null, cancellationToken).ConfigureAwait(false))
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='tileKey'>
            /// The tile id
            /// </param>
            /// <param name='requestParameters'>
            /// Clone tile parameters
            /// </param>
            public static Tile CloneTile(this IDashboards operations, string groupId, string dashboardKey, string tileKey, CloneTileRequest requestParameters)
            {
                return operations.CloneTileAsync(groupId, dashboardKey, tileKey, requestParameters).GetAwaiter().GetResult();
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='tileKey'>
            /// The tile id
            /// </param>
            /// <param name='requestParameters'>
            /// Clone tile parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Tile> CloneTileAsync(this IDashboards operations, string groupId, string dashboardKey, string tileKey, CloneTileRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CloneTileInGroupWithHttpMessagesAsync(groupId, dashboardKey, tileKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            public static EmbedToken GenerateToken(this IDashboards operations, string groupId, string dashboardKey, GenerateTokenRequest requestParameters)
            {
                return operations.GenerateTokenAsync(groupId, dashboardKey, requestParameters).GetAwaiter().GetResult();
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EmbedToken> GenerateTokenAsync(this IDashboards operations, string groupId, string dashboardKey, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, dashboardKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
