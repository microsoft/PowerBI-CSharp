namespace Microsoft.PowerBI.Api.V2
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Datasets.
    /// </summary>
    public static partial class DatasetsExtensions
    {
            /// <summary>
            /// Returns the datasets
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            public static ODataResponseListDataset GetDatasets(this IDatasets operations, string groupId)
            {
                return operations.GetDatasetsAsync(groupId).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the datasets
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
            public static async Task<ODataResponseListDataset> GetDatasetsAsync(this IDatasets operations, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetDatasetsInGroupWithHttpMessagesAsync(groupId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns a list of datasets from the specified workspace for an organization
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
            public static ODataResponseListDataset GetDatasetsAsAdmin(this IDatasets operations, string groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?))
            {
                return operations.GetDatasetsInGroupAsAdminAsync(groupId, filter, top, skip).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns a list of datasets from the specified workspace for an organization
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
            public static async Task<ODataResponseListDataset> GetDatasetsAsAdminAsync(this IDatasets operations, string groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetDatasetsInGroupAsAdminWithHttpMessagesAsync(groupId, filter, top, skip, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Post a new entity to datasets
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='dataset'>
            /// Create dataset parameters
            /// </param>
            public static object PostDataset(this IDatasets operations, string groupId, Dataset dataset)
            {
                return operations.PostDatasetAsync(groupId, dataset).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Post a new entity to datasets
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='dataset'>
            /// Create dataset parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PostDatasetAsync(this IDatasets operations, string groupId, Dataset dataset, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostDatasetInGroupWithHttpMessagesAsync(groupId, dataset, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the dataset metadata for the specifeid dataset id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            public static Dataset GetDatasetById(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.GetDatasetByIdAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the dataset metadata for the specifeid dataset id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Dataset> GetDatasetByIdAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetDatasetByIdInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the dataset with the specified id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            public static object DeleteDatasetById(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.DeleteDatasetByIdAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the dataset with the specified id
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> DeleteDatasetByIdAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteDatasetByIdInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all tables within the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            public static ODataResponseListTable GetTables(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.GetTablesAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all tables within the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListTable> GetTablesAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetTablesInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates a schema and metadata for the specified table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='tableName'>
            /// The table name
            /// </param>
            /// <param name='requestMessage'>
            /// The request message
            /// </param>
            public static object PutTable(this IDatasets operations, string groupId, string datasetKey, string tableName, object requestMessage)
            {
                return operations.PutTableAsync(groupId, datasetKey, tableName, requestMessage).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates a schema and metadata for the specified table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='tableName'>
            /// The table name
            /// </param>
            /// <param name='requestMessage'>
            /// The request message
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PutTableAsync(this IDatasets operations, string groupId, string datasetKey, string tableName, object requestMessage, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PutTableInGroupWithHttpMessagesAsync(groupId, datasetKey, tableName, requestMessage, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Posts new data rows into the specified table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='tableName'>
            /// The table name
            /// </param>
            /// <param name='requestMessage'>
            /// The request message
            /// </param>
            public static object PostRows(this IDatasets operations, string groupId, string datasetKey, string tableName, object requestMessage)
            {
                return operations.PostRowsAsync(groupId, datasetKey, tableName, requestMessage).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Posts new data rows into the specified table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='tableName'>
            /// The table name
            /// </param>
            /// <param name='requestMessage'>
            /// The request message
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PostRowsAsync(this IDatasets operations, string groupId, string datasetKey, string tableName, object requestMessage, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostRowsInGroupWithHttpMessagesAsync(groupId, datasetKey, tableName, requestMessage, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes all rows from the specified table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='tableName'>
            /// The table name
            /// </param>
            public static object DeleteRows(this IDatasets operations, string groupId, string datasetKey, string tableName)
            {
                return operations.DeleteRowsAsync(groupId, datasetKey, tableName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes all rows from the specified table
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='tableName'>
            /// The table name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> DeleteRowsAsync(this IDatasets operations, string groupId, string datasetKey, string tableName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteRowsInGroupWithHttpMessagesAsync(groupId, datasetKey, tableName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the dataset refresh history
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='top'>
            /// The requested number of entries in the refresh history, if not supported
            /// the default is all available entries
            /// </param>
            public static ODataResponseListRefresh GetRefreshHistory(this IDatasets operations, string groupId, string datasetKey, int? top = default(int?))
            {
                return operations.GetRefreshHistoryAsync(groupId, datasetKey, top).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the dataset refresh history
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='top'>
            /// The requested number of entries in the refresh history, if not supported
            /// the default is all available entries
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListRefresh> GetRefreshHistoryAsync(this IDatasets operations, string groupId, string datasetKey, int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetRefreshHistoryInGroupWithHttpMessagesAsync(groupId, datasetKey, top, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Start a dataset refresh
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            public static object RefreshDataset(this IDatasets operations, string groupId, string datasetKey, RefreshRequest refreshRequest = null)
            {
                return operations.RefreshDatasetAsync(groupId, datasetKey, refreshRequest).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Start a dataset refresh
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> RefreshDatasetAsync(this IDatasets operations, string groupId, string datasetKey, RefreshRequest refreshRequest = null, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RefreshDatasetInGroupWithHttpMessagesAsync(groupId, datasetKey, refreshRequest, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of datasource for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            public static ODataResponseListDatasource GetDatasources(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.GetDatasourcesAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of datasource for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListDatasource> GetDatasourcesAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetDatasourcesInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the dataset datasources using the specified datasource selectors
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='updateDatasourcesRequest'>
            /// </param>
            public static object UpdateDatasources(this IDatasets operations, string groupId, string datasetKey, UpdateDatasourcesRequest updateDatasourcesRequest)
            {
                return operations.UpdateDatasourcesAsync(groupId, datasetKey, updateDatasourcesRequest).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the dataset datasources using the specified datasource selectors
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='updateDatasourcesRequest'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateDatasourcesAsync(this IDatasets operations, string groupId, string datasetKey, UpdateDatasourcesRequest updateDatasourcesRequest, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateDatasourcesInGroupWithHttpMessagesAsync(groupId, datasetKey, updateDatasourcesRequest, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Sets all connections for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='parameters'>
            /// The body
            /// </param>
            public static object SetAllDatasetConnections(this IDatasets operations, string groupId, string datasetKey, ConnectionDetails parameters)
            {
                return operations.SetAllDatasetConnectionsAsync(groupId, datasetKey, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Sets all connections for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='parameters'>
            /// The body
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> SetAllDatasetConnectionsAsync(this IDatasets operations, string groupId, string datasetKey, ConnectionDetails parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SetAllDatasetConnectionsInGroupWithHttpMessagesAsync(groupId, datasetKey, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Bind dataset to gateway
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='bindToGatewayRequest'>
            /// The bind to gateway request
            /// </param>
            public static object BindToGateway(this IDatasets operations, string groupId, string datasetKey, BindToGatewayRequest bindToGatewayRequest)
            {
                return operations.BindToGatewayAsync(groupId, datasetKey, bindToGatewayRequest).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Bind dataset to gateway
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='bindToGatewayRequest'>
            /// The bind to gateway request
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> BindToGatewayAsync(this IDatasets operations, string groupId, string datasetKey, BindToGatewayRequest bindToGatewayRequest, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BindToGatewayInGroupWithHttpMessagesAsync(groupId, datasetKey, bindToGatewayRequest, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of bound gateway datasources for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            public static ODataResponseListGatewayDatasource GetGatewayDatasources(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.GetGatewayDatasourcesAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of bound gateway datasources for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListGatewayDatasource> GetGatewayDatasourcesAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetGatewayDatasourcesInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Take Over a dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            public static object TakeOver(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.TakeOverAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Take Over a dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> TakeOverAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.TakeOverInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Generate token to view the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            public static EmbedToken GenerateToken(this IDatasets operations, string groupId, string datasetKey, GenerateTokenRequest requestParameters)
            {
                return operations.GenerateTokenAsync(groupId, datasetKey, requestParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Generate token to view the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='requestParameters'>
            /// Generate token parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EmbedToken> GenerateTokenAsync(this IDatasets operations, string groupId, string datasetKey, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, datasetKey, requestParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
           
            /// <summary>
            /// Gets the refresh schedule for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            public static RefreshSchedule GetRefreshSchedule(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.GetRefreshScheduleInGroupAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the refresh schedule for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<RefreshSchedule> GetRefreshScheduleAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the dataset Refresh Schedule
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshScheduleRequest'>
            /// Patch Refresh Schedule parameters, by specifying all or some of the parameters
            /// </param>
            public static object UpdateRefreshSchedule(this IDatasets operations, string groupId, string datasetKey, RefreshScheduleRequest datasetModelRefreshScheduleRequest)
            {
                return operations.UpdateRefreshScheduleInGroupAsync(groupId, datasetKey, datasetModelRefreshScheduleRequest).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the dataset Refresh Schedule
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshScheduleRequest'>
            /// Patch Refresh Schedule parameters, by specifying all or some of the parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateRefreshScheduleAsync(this IDatasets operations, string groupId, string datasetKey, RefreshScheduleRequest datasetModelRefreshScheduleRequest, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, datasetModelRefreshScheduleRequest, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the refresh schedule for the specified DirectQuery or LiveConnection dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            public static DirectQueryRefreshSchedule GetDirectQueryRefreshSchedule(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.GetDirectQueryRefreshScheduleInGroupAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the refresh schedule for the specified DirectQuery or LiveConnection dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<DirectQueryRefreshSchedule> GetDirectQueryRefreshScheduleAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the dataset DirectQuery Refresh Schedule
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshScheduleRequest'>
            /// Patch DirectQuery Refresh Schedule parameters, by specifying all or some of the parameters
            /// </param>
            public static object UpdateDirectQueryRefreshSchedule(this IDatasets operations, string groupId, string datasetKey, DirectQueryRefreshScheduleRequest datasetDQRefreshScheduleRequest)
            {
                return operations.UpdateDirectQueryRefreshScheduleInGroupAsync(groupId, datasetKey, datasetDQRefreshScheduleRequest).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the dataset DirectQuery Refresh Schedule
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshScheduleRequest'>
            /// Patch DirectQuery Refresh Schedule parameters, by specifying all or some of the parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateDirectQueryRefreshScheduleAsync(this IDatasets operations, string groupId, string datasetKey, DirectQueryRefreshScheduleRequest datasetDQRefreshScheduleRequest, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, datasetDQRefreshScheduleRequest, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the refresh schedule for the specified dataset from **"My
            /// Workspace"**.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request that disables the refresh schedule should
            /// contain no other changes.&lt;br/&gt;The days array should not be set to
            /// empty array.&lt;br/&gt;The times may be set to empty array (in which case
            /// Power BI will use a default single time per day).&lt;br/&gt;The limit on
            /// number of time slots per day depends on the type of capacity used (Premium
            /// or Shared), see [What is Microsoft Power BI
            /// Premium](https://docs.microsoft.com/en-us/power-bi/service-premium).&lt;br/&gt;&lt;br/&gt;**Required
            /// scope**: Dataset.ReadWrite.All &lt;br/&gt;To set the permissions scope, see
            /// [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshSchedule'>
            /// Update Refresh Schedule parameters, by specifying all or some of the
            /// parameters
            /// </param>
            public static object UpdateRefreshSchedule(this IDatasets operations, string datasetKey, RefreshSchedule datasetModelRefreshSchedule)
            {
                return operations.UpdateRefreshScheduleAsync(datasetKey, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the refresh schedule for the specified dataset from **"My
            /// Workspace"**.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request that disables the refresh schedule should
            /// contain no other changes.&lt;br/&gt;The days array should not be set to
            /// empty array.&lt;br/&gt;The times may be set to empty array (in which case
            /// Power BI will use a default single time per day).&lt;br/&gt;The limit on
            /// number of time slots per day depends on the type of capacity used (Premium
            /// or Shared), see [What is Microsoft Power BI
            /// Premium](https://docs.microsoft.com/en-us/power-bi/service-premium).&lt;br/&gt;&lt;br/&gt;**Required
            /// scope**: Dataset.ReadWrite.All &lt;br/&gt;To set the permissions scope, see
            /// [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshSchedule'>
            /// Update Refresh Schedule parameters, by specifying all or some of the
            /// parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateRefreshScheduleAsync(this IDatasets operations, string datasetKey, RefreshSchedule datasetModelRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateRefreshScheduleWithHttpMessagesAsync(datasetKey, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the refresh schedule for the specified DirectQuery or
            /// LiveConnection dataset from **"My Workspace"**.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request should contain either a combination of days and
            /// times  (setting times is optional, otherwise a default single time per day
            /// is used) or a valid frequency, but not both.&lt;br/&gt;Setting frequency
            /// will automatically truncate the days and times
            /// arrays.&lt;br/&gt;&lt;br/&gt;**Required scope**: Dataset.ReadWrite.All
            /// &lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshSchedule'>
            /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
            /// specifying all or some of the parameters
            /// </param>
            public static object UpdateDirectQueryRefreshSchedule(this IDatasets operations, string datasetKey, DirectQueryRefreshSchedule datasetDQRefreshSchedule)
            {
                return operations.UpdateDirectQueryRefreshScheduleAsync(datasetKey, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the refresh schedule for the specified DirectQuery or
            /// LiveConnection dataset from **"My Workspace"**.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request should contain either a combination of days and
            /// times  (setting times is optional, otherwise a default single time per day
            /// is used) or a valid frequency, but not both.&lt;br/&gt;Setting frequency
            /// will automatically truncate the days and times
            /// arrays.&lt;br/&gt;&lt;br/&gt;**Required scope**: Dataset.ReadWrite.All
            /// &lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshSchedule'>
            /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
            /// specifying all or some of the parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateDirectQueryRefreshScheduleAsync(this IDatasets operations, string datasetKey, DirectQueryRefreshSchedule datasetDQRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateDirectQueryRefreshScheduleWithHttpMessagesAsync(datasetKey, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the refresh schedule for the specified dataset from the specified
            /// workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request that disables the refresh schedule should
            /// contain no other changes.&lt;br/&gt;The days array should not be set to
            /// empty array.&lt;br/&gt;The times may be set to empty array (in which case
            /// Power BI will use a default single time per day).&lt;br/&gt;The limit on
            /// number of time slots per day depends on the type of capacity used (Premium
            /// or Shared), see [What is Microsoft Power BI
            /// Premium](https://docs.microsoft.com/en-us/power-bi/service-premium).&lt;br/&gt;&lt;br/&gt;**Required
            /// scope**: Dataset.ReadWrite.All &lt;br/&gt;To set the permissions scope, see
            /// [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshSchedule'>
            /// Update Refresh Schedule parameters, by specifying all or some of the
            /// parameters
            /// </param>
            public static object UpdateRefreshScheduleInGroup(this IDatasets operations, string groupId, string datasetKey, RefreshSchedule datasetModelRefreshSchedule)
            {
                return operations.UpdateRefreshScheduleInGroupAsync(groupId, datasetKey, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the refresh schedule for the specified dataset from the specified
            /// workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request that disables the refresh schedule should
            /// contain no other changes.&lt;br/&gt;The days array should not be set to
            /// empty array.&lt;br/&gt;The times may be set to empty array (in which case
            /// Power BI will use a default single time per day).&lt;br/&gt;The limit on
            /// number of time slots per day depends on the type of capacity used (Premium
            /// or Shared), see [What is Microsoft Power BI
            /// Premium](https://docs.microsoft.com/en-us/power-bi/service-premium).&lt;br/&gt;&lt;br/&gt;**Required
            /// scope**: Dataset.ReadWrite.All &lt;br/&gt;To set the permissions scope, see
            /// [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshSchedule'>
            /// Update Refresh Schedule parameters, by specifying all or some of the
            /// parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateRefreshScheduleInGroupAsync(this IDatasets operations, string groupId, string datasetKey, RefreshSchedule datasetModelRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the refresh schedule for the specified DirectQuery or
            /// LiveConnection dataset from the specified workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request should contain either a combination of days and
            /// times  (setting times is optional, otherwise a default single time per day
            /// is used) or a valid frequency, but not both.&lt;br/&gt;Setting frequency
            /// will automatically truncate the days and times
            /// arrays.&lt;br/&gt;&lt;br/&gt;**Required scope**: Dataset.ReadWrite.All
            /// &lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshSchedule'>
            /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
            /// specifying all or some of the parameters
            /// </param>
            public static object UpdateDirectQueryRefreshScheduleInGroup(this IDatasets operations, string groupId, string datasetKey, DirectQueryRefreshSchedule datasetDQRefreshSchedule)
            {
                return operations.UpdateDirectQueryRefreshScheduleInGroupAsync(groupId, datasetKey, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the refresh schedule for the specified DirectQuery or
            /// LiveConnection dataset from the specified workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request should contain either a combination of days and
            /// times  (setting times is optional, otherwise a default single time per day
            /// is used) or a valid frequency, but not both.&lt;br/&gt;Setting frequency
            /// will automatically truncate the days and times
            /// arrays.&lt;br/&gt;&lt;br/&gt;**Required scope**: Dataset.ReadWrite.All
            /// &lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshSchedule'>
            /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
            /// specifying all or some of the parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateDirectQueryRefreshScheduleInGroupAsync(this IDatasets operations, string groupId, string datasetKey, DirectQueryRefreshSchedule datasetDQRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the refresh schedule for the specified dataset from the specified
            /// workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request that disables the refresh schedule should
            /// contain no other changes.&lt;br/&gt;The days array should not be set to
            /// empty array.&lt;br/&gt;The times may be set to empty array (in which case
            /// Power BI will use a default single time per day).&lt;br/&gt;The limit on
            /// number of time slots per day depends on the type of capacity used (Premium
            /// or Shared), see [What is Microsoft Power BI
            /// Premium](https://docs.microsoft.com/en-us/power-bi/service-premium).&lt;br/&gt;&lt;br/&gt;**Required
            /// scope**: Dataset.ReadWrite.All &lt;br/&gt;To set the permissions scope, see
            /// [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshSchedule'>
            /// Update Refresh Schedule parameters, by specifying all or some of the
            /// parameters
            /// </param>
            public static object UpdateRefreshSchedule(this IDatasets operations, string groupId, string datasetKey, RefreshSchedule datasetModelRefreshSchedule)
            {
                return operations.UpdateRefreshScheduleInGroupAsync(groupId, datasetKey, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the refresh schedule for the specified dataset from the specified
            /// workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request that disables the refresh schedule should
            /// contain no other changes.&lt;br/&gt;The days array should not be set to
            /// empty array.&lt;br/&gt;The times may be set to empty array (in which case
            /// Power BI will use a default single time per day).&lt;br/&gt;The limit on
            /// number of time slots per day depends on the type of capacity used (Premium
            /// or Shared), see [What is Microsoft Power BI
            /// Premium](https://docs.microsoft.com/en-us/power-bi/service-premium).&lt;br/&gt;&lt;br/&gt;**Required
            /// scope**: Dataset.ReadWrite.All &lt;br/&gt;To set the permissions scope, see
            /// [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetModelRefreshSchedule'>
            /// Update Refresh Schedule parameters, by specifying all or some of the
            /// parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateRefreshScheduleAsync(this IDatasets operations, string groupId, string datasetKey, RefreshSchedule datasetModelRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the refresh schedule for the specified DirectQuery or
            /// LiveConnection dataset from the specified workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request should contain either a combination of days and
            /// times  (setting times is optional, otherwise a default single time per day
            /// is used) or a valid frequency, but not both.&lt;br/&gt;Setting frequency
            /// will automatically truncate the days and times
            /// arrays.&lt;br/&gt;&lt;br/&gt;**Required scope**: Dataset.ReadWrite.All
            /// &lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshSchedule'>
            /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
            /// specifying all or some of the parameters
            /// </param>
            public static object UpdateDirectQueryRefreshSchedule(this IDatasets operations, string groupId, string datasetKey, DirectQueryRefreshSchedule datasetDQRefreshSchedule)
            {
                return operations.UpdateDirectQueryRefreshScheduleInGroupAsync(groupId, datasetKey, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the refresh schedule for the specified DirectQuery or
            /// LiveConnection dataset from the specified workspace.
            /// </summary>
            /// <remarks>
            /// &lt;br/&gt;This operation is only supported for the dataset
            /// owner.&lt;br/&gt;A request should contain either a combination of days and
            /// times  (setting times is optional, otherwise a default single time per day
            /// is used) or a valid frequency, but not both.&lt;br/&gt;Setting frequency
            /// will automatically truncate the days and times
            /// arrays.&lt;br/&gt;&lt;br/&gt;**Required scope**: Dataset.ReadWrite.All
            /// &lt;br/&gt;To set the permissions scope, see [Register an
            /// app](https://docs.microsoft.com/power-bi/developer/register-app).
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The workspace id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='datasetDQRefreshSchedule'>
            /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
            /// specifying all or some of the parameters
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateDirectQueryRefreshScheduleAsync(this IDatasets operations, string groupId, string datasetKey, DirectQueryRefreshSchedule datasetDQRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetKey, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of parameters for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            public static ODataResponseListDatasetParameter GetParameters(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.GetParametersInGroupAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of parameters for the specified dataset
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListDatasetParameter> GetParametersAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetParametersInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Updates the dataset parameters
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='updateDatasetParametersRequest'>
            /// </param>
            public static object UpdateParameters(this IDatasets operations, string groupId, string datasetKey, UpdateDatasetParametersRequest updateDatasetParametersRequest)
            {
                return operations.UpdateParametersInGroupAsync(groupId, datasetKey, updateDatasetParametersRequest).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the dataset parameters
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// </param>
            /// <param name='updateDatasetParametersRequest'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> UpdateParametersAsync(this IDatasets operations, string groupId, string datasetKey, UpdateDatasetParametersRequest updateDatasetParametersRequest, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateParametersInGroupWithHttpMessagesAsync(groupId, datasetKey, updateDatasetParametersRequest, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of gateways to bind
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            public static ODataResponseListGateway DiscoverGateways(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.DiscoverGatewaysInGroupAsync(groupId, datasetKey).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of gateways to bind
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='groupId'>
            /// The group id
            /// </param>
            /// <param name='datasetKey'>
            /// The dataset id
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ODataResponseListGateway> DiscoverGatewaysAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DiscoverGatewaysInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }
    }
}
