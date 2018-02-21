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
            public static object RefreshDataset(this IDatasets operations, string groupId, string datasetKey)
            {
                return operations.RefreshDatasetAsync(groupId, datasetKey).GetAwaiter().GetResult();
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
            public static async Task<object> RefreshDatasetAsync(this IDatasets operations, string groupId, string datasetKey, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RefreshDatasetInGroupWithHttpMessagesAsync(groupId, datasetKey, null, cancellationToken).ConfigureAwait(false))
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
