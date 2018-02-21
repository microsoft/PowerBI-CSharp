namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Tiles.
    /// </summary>
    public static partial class TilesExtensions
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='tileKey'>
            /// The tile id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            public static EmbedToken GenerateToken(this ITiles operations, string groupId, string dashboardKey, string tileKey, GenerateTokenRequest requestParameters)
            {
                return operations.GenerateTokenAsync(groupId, dashboardKey, tileKey, requestParameters).GetAwaiter().GetResult();
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
            /// <param name='dashboardKey'>
            /// The dashboard id
            /// </param>
            /// <param name='tileKey'>
            /// The tile id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EmbedToken> GenerateTokenAsync(this ITiles operations, string groupId, string dashboardKey, string tileKey, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, dashboardKey, tileKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
