// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.PowerBI.Api.V1
{
    using Microsoft.PowerBI;
    using Microsoft.PowerBI.Api;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for WorkspacesOperations.
    /// </summary>
    public static partial class WorkspacesOperationsExtensions
    {
            /// <summary>
            /// Returns a list of workspaces for the specified collection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='collectionName'>
            /// The workspace collection name
            /// </param>
            public static ODataResponseListWorkspace GetWorkspacesByCollectionName(this IWorkspacesOperations operations, string collectionName)
            {
                return operations.GetWorkspacesByCollectionNameAsync(collectionName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns a list of workspaces for the specified collection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='collectionName'>
            /// The workspace collection name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListWorkspace> GetWorkspacesByCollectionNameAsync(this IWorkspacesOperations operations, string collectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWorkspacesByCollectionNameWithHttpMessagesAsync(collectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a new workspace within a workspace collection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='collectionName'>
            /// The workspace collection name
            /// </param>
            /// <param name='workspaceRequest'>
            /// The workspace requested to create
            /// </param>
            public static Workspace PostWorkspace(this IWorkspacesOperations operations, string collectionName, CreateWorkspaceRequest workspaceRequest = default(CreateWorkspaceRequest))
            {
                return operations.PostWorkspaceAsync(collectionName, workspaceRequest).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a new workspace within a workspace collection
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='collectionName'>
            /// The workspace collection name
            /// </param>
            /// <param name='workspaceRequest'>
            /// The workspace requested to create
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Workspace> PostWorkspaceAsync(this IWorkspacesOperations operations, string collectionName, CreateWorkspaceRequest workspaceRequest = default(CreateWorkspaceRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostWorkspaceWithHttpMessagesAsync(collectionName, workspaceRequest, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}