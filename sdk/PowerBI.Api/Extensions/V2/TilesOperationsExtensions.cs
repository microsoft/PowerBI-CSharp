namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Tiles.
    /// </summary>
    public static partial class TilesOperationsExtensions
    {
        /// <summary>
        /// Generate token to view the specified tile
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
        /// Generate token parameters
        /// </param>
        public static EmbedToken GenerateToken(this ITilesOperations operations, Guid groupId, Guid dashboardId, Guid tileId, GenerateTokenRequest requestParameters)
        {
            return operations.GenerateTokenAsync(groupId, dashboardId, tileId, requestParameters).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Generate token to view the specified tile
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
        /// Generate token parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EmbedToken> GenerateTokenAsync(this ITilesOperations operations, Guid groupId, Guid dashboardId, Guid tileId, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, dashboardId, tileId, requestParameters, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
