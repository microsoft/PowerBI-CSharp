namespace Microsoft.PowerBI.Api
{
    using Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Datasets.
    /// </summary>
    public static partial class DatasetsOperationsExtensions
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
        public static Datasets GetDatasets(this IDatasetsOperations operations, Guid groupId)
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
        public static async Task<Datasets> GetDatasetsAsync(this IDatasetsOperations operations, Guid groupId, CancellationToken cancellationToken = default(CancellationToken))
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
        /// <param name='expand'>
        /// Expands related entities inline
        /// </param>
        public static AdminDatasets GetDatasetsAsAdmin(this IDatasetsOperations operations, Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?), string expand = default(string))
        {
            return operations.GetDatasetsInGroupAsAdminAsync(groupId, filter, top, skip, expand).GetAwaiter().GetResult();
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
        /// <param name='expand'>
        /// Expands related entities inline
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<AdminDatasets> GetDatasetsAsAdminAsync(this IDatasetsOperations operations, Guid groupId, string filter = default(string), int? top = default(int?), int? skip = default(int?), string expand = default(string), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatasetsInGroupAsAdminWithHttpMessagesAsync(groupId, filter, top, skip, expand, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }


        /// <summary>
        /// Returns a list of upstream dataflows for datasets from the specified workspace.
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
        public static DatasetToDataflowLinksResponse GetDatasetToDataflowsLinksAsAdmin(this IDatasetsOperations operations, System.Guid groupId)
        {
            return operations.GetDatasetToDataflowsLinksInGroupAsAdmin(groupId);
        }

        /// <summary>
        /// Returns a list of upstream dataflows for datasets from the specified workspace.
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
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        public static async Task<DatasetToDataflowLinksResponse> GetDatasetToDataflowsLinksAsAdminAsync(this IDatasetsOperations operations, System.Guid groupId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatasetToDataflowsLinksInGroupAsAdminWithHttpMessagesAsync(groupId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Returns a list of upstream dataflows for datasets from the specified workspace.
        /// </summary>
        /// <remarks>
        /// <br/>**Required scope**: Dataset.ReadWrite.All or Dataset.Read.All <br/>
        /// To set the permissions scope, see [Register an app](https://docs.microsoft.com/power-bi/developer/register-app).,
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        public static DatasetToDataflowLinksResponse GetDatasetToDataflowsLinks(this IDatasetsOperations operations, System.Guid groupId)
        {
            return operations.GetDatasetToDataflowsLinksInGroup(groupId);
        }
        /// <summary>
        /// Returns a list of upstream dataflows for datasets from the specified workspace.
        /// </summary>
        /// <remarks>
        /// <br/>**Required scope**: Dataset.ReadWrite.All or Dataset.Read.All <br/>
        /// To set the permissions scope, see [Register an app](https://docs.microsoft.com/power-bi/developer/register-app).,
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace id
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        public static async Task<DatasetToDataflowLinksResponse> GetDatasetToDataflowsLinksAsync(this IDatasetsOperations operations, System.Guid groupId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatasetToDataflowsLinksInGroupWithHttpMessagesAsync(groupId, null, cancellationToken).ConfigureAwait(false))
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
        public static Dataset PostDataset(this IDatasetsOperations operations, Guid groupId, CreateDatasetRequest dataset, DefaultRetentionPolicy? defaultRetentionPolicy = default(DefaultRetentionPolicy?))
        {
            return operations.PostDatasetAsync(groupId, dataset, defaultRetentionPolicy).GetAwaiter().GetResult();
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
        public static async Task<Dataset> PostDatasetAsync(this IDatasetsOperations operations, Guid groupId, CreateDatasetRequest dataset, DefaultRetentionPolicy? defaultRetentionPolicy = default(DefaultRetentionPolicy?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PostDatasetInGroupWithHttpMessagesAsync(groupId, dataset, defaultRetentionPolicy, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        public static Dataset GetDataset(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetDatasetAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Dataset> GetDatasetAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatasetInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Updates the dataset with the specified id
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='updateDatasetRequest'>
        /// Update dataset request parameters
        /// </param>
        public static void UpdateDataset(this IDatasetsOperations operations, Guid groupId, string datasetId, UpdateDatasetRequest updateDatasetRequest)
        {
            operations.UpdateDatasetAsync(groupId, datasetId, updateDatasetRequest).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Updates the dataset with the specified id
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateDatasetAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, UpdateDatasetRequest updateDatasetRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateDatasetInGroupWithHttpMessagesAsync(groupId, datasetId, updateDatasetRequest, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        public static void DeleteDataset(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            operations.DeleteDatasetAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task DeleteDatasetAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.DeleteDatasetInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        public static Tables GetTables(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetTablesAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Tables> GetTablesAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetTablesInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='tableName'>
        /// The table name
        /// </param>
        /// <param name='requestMessage'>
        /// The request message
        /// </param>
        public static Table PutTable(this IDatasetsOperations operations, Guid groupId, string datasetId, string tableName, Table requestMessage)
        {
            return operations.PutTableAsync(groupId, datasetId, tableName, requestMessage).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
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
        public static async Task<Table> PutTableAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, string tableName, Table requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.PutTableInGroupWithHttpMessagesAsync(groupId, datasetId, tableName, requestMessage, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='tableName'>
        /// The table name
        /// </param>
        /// <param name='requestMessage'>
        /// The request message
        /// </param>
        public static void PostRows(this IDatasetsOperations operations, Guid groupId, string datasetId, string tableName, PostRowsRequest requestMessage)
        {
            operations.PostRowsAsync(groupId, datasetId, tableName, requestMessage).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
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
        public static async Task PostRowsAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, string tableName, PostRowsRequest requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.PostRowsInGroupWithHttpMessagesAsync(groupId, datasetId, tableName, requestMessage, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='tableName'>
        /// The table name
        /// </param>
        public static void DeleteRows(this IDatasetsOperations operations, Guid groupId, string datasetId, string tableName)
        {
            operations.DeleteRowsAsync(groupId, datasetId, tableName).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='tableName'>
        /// The table name
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task DeleteRowsAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, string tableName, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.DeleteRowsInGroupWithHttpMessagesAsync(groupId, datasetId, tableName, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='top'>
        /// The requested number of entries in the refresh history, if not supported
        /// the default is all available entries
        /// </param>
        public static Refreshes GetRefreshHistory(this IDatasetsOperations operations, Guid groupId, string datasetId, int? top = default(int?))
        {
            return operations.GetRefreshHistoryAsync(groupId, datasetId, top).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='top'>
        /// The requested number of entries in the refresh history, if not supported
        /// the default is all available entries
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Refreshes> GetRefreshHistoryAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, int? top = default(int?), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetRefreshHistoryInGroupWithHttpMessagesAsync(groupId, datasetId, top, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Triggers a refresh for the specified dataset from the specified workspace.
        /// An [asynchronous refresh](/power-bi/connect-data/asynchronous-refresh)
        /// would be triggered only if any request payload except `notifyOption` is
        /// set. Asynchronous refresh has a response header, `Location`, which is an
        /// URI to [get refresh execution details in
        /// group](/rest/api/power-bi/datasets/get-refresh-execution-details-in-group).
        /// </summary>
        /// <remarks>
        ///
        /// ## Required scope
        ///
        /// Dataset.ReadWrite.All
        ///
        /// ## Limitations
        ///
        /// - For Shared capacities, a maximum of eight requests per day, which
        /// includes refreshes executed using a scheduled refresh.
        /// - For Premium capacities, the maximum requests per day is only limited by
        /// the available resources in the capacity. If available resources are
        /// overloaded, refreshes are throttled until the load is reduced. The refresh
        /// will fail if throttling exceeds 1 hour.
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='datasetRefreshRequest'>
        /// </param>
        public static DatasetsRefreshDatasetInGroupHeaders RefreshDataset(this IDatasetsOperations operations, System.Guid groupId, string datasetId, DatasetRefreshRequest datasetRefreshRequest = default(DatasetRefreshRequest))
        {
            return operations.RefreshDatasetAsync(groupId, datasetId, datasetRefreshRequest).GetAwaiter().GetResult();
        }

        /// <summary>GetDatasources
        /// Triggers a refresh for the specified dataset from the specified workspace.
        /// An [asynchronous refresh](/power-bi/connect-data/asynchronous-refresh)
        /// would be triggered only if any request payload except `notifyOption` is
        /// set. Asynchronous refresh has a response header, `Location`, which is an
        /// URI to [get refresh execution details in
        /// group](/rest/api/power-bi/datasets/get-refresh-execution-details-in-group).
        /// </summary>
        /// <remarks>
        ///
        /// ## Required scope
        ///
        /// Dataset.ReadWrite.All
        ///
        /// ## Limitations
        ///
        /// - For Shared capacities, a maximum of eight requests per day, which
        /// includes refreshes executed using a scheduled refresh.
        /// - For Premium capacities, the maximum requests per day is only limited by
        /// the available resources in the capacity. If available resources are
        /// overloaded, refreshes are throttled until the load is reduced. The refresh
        /// will fail if throttling exceeds 1 hour.
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='datasetRefreshRequest'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<DatasetsRefreshDatasetInGroupHeaders> RefreshDatasetAsync(this IDatasetsOperations operations, System.Guid groupId, string datasetId, DatasetRefreshRequest datasetRefreshRequest = default(DatasetRefreshRequest), CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.RefreshDatasetInGroupWithHttpMessagesAsync(groupId, datasetId, datasetRefreshRequest, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Headers;
            }
        }

        /// <summary>
        /// Returns execution details of an [asynchronous refresh
        /// operation](/power-bi/connect-data/asynchronous-refresh) for the specified
        /// dataset from the specified workspace.
        /// </summary>
        /// <remarks>
        ///
        /// ## Required scope
        ///
        /// Dataset.ReadWrite.All or Dataset.Read.All
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='refreshId'>
        /// The refresh ID
        /// </param>
        public static DatasetRefreshDetail GetRefreshExecutionDetails(this IDatasetsOperations operations, System.Guid groupId, System.Guid datasetId, System.Guid refreshId)
        {
            return operations.GetRefreshExecutionDetailsAsync(groupId, datasetId, refreshId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns execution details of an [asynchronous refresh
        /// operation](/power-bi/connect-data/asynchronous-refresh) for the specified
        /// dataset from the specified workspace.
        /// </summary>
        /// <remarks>
        ///
        /// ## Required scope
        ///
        /// Dataset.ReadWrite.All or Dataset.Read.All
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='refreshId'>
        /// The refresh ID
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<DatasetRefreshDetail> GetRefreshExecutionDetailsAsync(this IDatasetsOperations operations, System.Guid groupId, System.Guid datasetId, System.Guid refreshId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetRefreshExecutionDetailsInGroupWithHttpMessagesAsync(groupId, datasetId, refreshId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Cancels the specified refresh operation.
        /// </summary>
        /// <remarks>
        ///
        /// ## Required scope
        ///
        /// Dataset.ReadWrite.All
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='refreshId'>
        /// The refresh ID
        /// </param>
        public static void CancelRefresh(this IDatasetsOperations operations, System.Guid groupId, System.Guid datasetId, System.Guid refreshId)
        {
            operations.CancelRefreshAsync(groupId, datasetId, refreshId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Cancels the specified refresh operation.
        /// </summary>
        /// <remarks>
        ///
        /// ## Required scope
        ///
        /// Dataset.ReadWrite.All
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='refreshId'>
        /// The refresh ID
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task CancelRefreshAsync(this IDatasetsOperations operations, System.Guid groupId, System.Guid datasetId, System.Guid refreshId, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.CancelRefreshInGroupWithHttpMessagesAsync(groupId, datasetId, refreshId, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// </param>
        public static Datasources GetDatasources(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetDatasourcesAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Datasources> GetDatasourcesAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatasourcesInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Grants the specified user the specified permissions to the specified dataset
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// </param>
        /// <param name='userDetails'>
        /// Details of user access right
        /// </param>
        public static void PostDatasetUser(this IDatasetsOperations operations, Guid groupId, string datasetId, PostDatasetUserAccess userDetails)
        {
            operations.PostDatasetUserAsync(groupId, datasetId, userDetails).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Grants the specified user the specified permissions to the specified dataset
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// </param>
        /// <param name='userDetails'>
        /// Details of user access right
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task PostDatasetUserAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, PostDatasetUserAccess userDetails, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.PostDatasetUserInGroupWithHttpMessagesAsync(groupId, datasetId, userDetails, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        /// <summary>
        /// Updates the specified principal's specified dataset permissions to the specified permissions
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// </param>
        /// <param name='userDetails'>
        /// Details of user access right
        /// </param>
        public static void PutDatasetUser(this IDatasetsOperations operations, Guid groupId, string datasetId, DatasetUserAccess userDetails)
        {
            operations.PutDatasetUserAsync(groupId, datasetId, userDetails).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Updates the specified principal's specified dataset permissions to the specified permissions
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The group id
        /// </param>
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// </param>
        /// <param name='userDetails'>
        /// Details of user access right
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task PutDatasetUserAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, DatasetUserAccess userDetails, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.PutDatasetUserInGroupWithHttpMessagesAsync(groupId, datasetId, userDetails, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        /// <summary>
        /// Returns a list of principals that have access to the specified dataset.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        public static DatasetUsersAccess GetDatasetUsers(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetDatasetUsersAsync(groupId, datasetId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Returns a list of principals that have access to the specified dataset.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<DatasetUsersAccess> GetDatasetUsersAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDatasetUsersInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='updateDatasourcesRequest'>
        /// </param>
        public static void UpdateDatasources(this IDatasetsOperations operations, Guid groupId, string datasetId, UpdateDatasourcesRequest updateDatasourcesRequest)
        {
            operations.UpdateDatasourcesAsync(groupId, datasetId, updateDatasourcesRequest).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='updateDatasourcesRequest'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateDatasourcesAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, UpdateDatasourcesRequest updateDatasourcesRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateDatasourcesInGroupWithHttpMessagesAsync(groupId, datasetId, updateDatasourcesRequest, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='parameters'>
        /// The body
        /// </param>
        public static void SetAllDatasetConnections(this IDatasetsOperations operations, Guid groupId, string datasetId, ConnectionDetails parameters)
        {
            operations.SetAllDatasetConnectionsAsync(groupId, datasetId, parameters).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='parameters'>
        /// The body
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task SetAllDatasetConnectionsAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, ConnectionDetails parameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.SetAllDatasetConnectionsInGroupWithHttpMessagesAsync(groupId, datasetId, parameters, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='bindToGatewayRequest'>
        /// The bind to gateway request
        /// </param>
        public static void BindToGateway(this IDatasetsOperations operations, Guid groupId, string datasetId, BindToGatewayRequest bindToGatewayRequest)
        {
            operations.BindToGatewayAsync(groupId, datasetId, bindToGatewayRequest).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='bindToGatewayRequest'>
        /// The bind to gateway request
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task BindToGatewayAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, BindToGatewayRequest bindToGatewayRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.BindToGatewayInGroupWithHttpMessagesAsync(groupId, datasetId, bindToGatewayRequest, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        public static GatewayDatasources GetGatewayDatasources(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetGatewayDatasourcesAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<GatewayDatasources> GetGatewayDatasourcesAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetGatewayDatasourcesInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        public static void TakeOver(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            operations.TakeOverAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task TakeOverAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.TakeOverInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='requestParameters'>
        /// Generate token parameters
        /// </param>
        public static EmbedToken GenerateToken(this IDatasetsOperations operations, Guid groupId, string datasetId, GenerateTokenRequest requestParameters)
        {
            return operations.GenerateTokenAsync(groupId, datasetId, requestParameters).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='requestParameters'>
        /// Generate token parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<EmbedToken> GenerateTokenAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, GenerateTokenRequest requestParameters, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GenerateTokenInGroupWithHttpMessagesAsync(groupId, datasetId, requestParameters, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// </param>
        public static RefreshSchedule GetRefreshSchedule(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetRefreshScheduleInGroupAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<RefreshSchedule> GetRefreshScheduleAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshScheduleRequest'>
        /// Patch Refresh Schedule parameters, by specifying all or some of the parameters
        /// </param>
        public static void UpdateRefreshSchedule(this IDatasetsOperations operations, Guid groupId, string datasetId, RefreshScheduleRequest datasetModelRefreshScheduleRequest)
        {
            operations.UpdateRefreshScheduleInGroupAsync(groupId, datasetId, datasetModelRefreshScheduleRequest).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshScheduleRequest'>
        /// Patch Refresh Schedule parameters, by specifying all or some of the parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateRefreshScheduleAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, RefreshScheduleRequest datasetModelRefreshScheduleRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, datasetModelRefreshScheduleRequest, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// </param>
        public static DirectQueryRefreshSchedule GetDirectQueryRefreshSchedule(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetDirectQueryRefreshScheduleInGroupAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<DirectQueryRefreshSchedule> GetDirectQueryRefreshScheduleAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshScheduleRequest'>
        /// Patch DirectQuery Refresh Schedule parameters, by specifying all or some of the parameters
        /// </param>
        public static void UpdateDirectQueryRefreshSchedule(this IDatasetsOperations operations, Guid groupId, string datasetId, DirectQueryRefreshScheduleRequest datasetDQRefreshScheduleRequest)
        {
            operations.UpdateDirectQueryRefreshScheduleInGroupAsync(groupId, datasetId, datasetDQRefreshScheduleRequest).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshScheduleRequest'>
        /// Patch DirectQuery Refresh Schedule parameters, by specifying all or some of the parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateDirectQueryRefreshScheduleAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, DirectQueryRefreshScheduleRequest datasetDQRefreshScheduleRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, datasetDQRefreshScheduleRequest, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshSchedule'>
        /// Update Refresh Schedule parameters, by specifying all or some of the
        /// parameters
        /// </param>
        public static void UpdateRefreshSchedule(this IDatasetsOperations operations, string datasetId, RefreshSchedule datasetModelRefreshSchedule)
        {
            operations.UpdateRefreshScheduleAsync(datasetId, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshSchedule'>
        /// Update Refresh Schedule parameters, by specifying all or some of the
        /// parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateRefreshScheduleAsync(this IDatasetsOperations operations, string datasetId, RefreshSchedule datasetModelRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateRefreshScheduleWithHttpMessagesAsync(datasetId, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshSchedule'>
        /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
        /// specifying all or some of the parameters
        /// </param>
        public static void UpdateDirectQueryRefreshSchedule(this IDatasetsOperations operations, string datasetId, DirectQueryRefreshSchedule datasetDQRefreshSchedule)
        {
            operations.UpdateDirectQueryRefreshScheduleAsync(datasetId, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshSchedule'>
        /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
        /// specifying all or some of the parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateDirectQueryRefreshScheduleAsync(this IDatasetsOperations operations, string datasetId, DirectQueryRefreshSchedule datasetDQRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateDirectQueryRefreshScheduleWithHttpMessagesAsync(datasetId, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshSchedule'>
        /// Update Refresh Schedule parameters, by specifying all or some of the
        /// parameters
        /// </param>
        public static void UpdateRefreshScheduleInGroup(this IDatasetsOperations operations, Guid groupId, string datasetId, RefreshSchedule datasetModelRefreshSchedule)
        {
            operations.UpdateRefreshScheduleInGroupAsync(groupId, datasetId, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshSchedule'>
        /// Update Refresh Schedule parameters, by specifying all or some of the
        /// parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateRefreshScheduleInGroupAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, RefreshSchedule datasetModelRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshSchedule'>
        /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
        /// specifying all or some of the parameters
        /// </param>
        public static void UpdateDirectQueryRefreshScheduleInGroup(this IDatasetsOperations operations, Guid groupId, string datasetId, DirectQueryRefreshSchedule datasetDQRefreshSchedule)
        {
            operations.UpdateDirectQueryRefreshScheduleInGroupAsync(groupId, datasetId, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshSchedule'>
        /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
        /// specifying all or some of the parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateDirectQueryRefreshScheduleInGroupAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, DirectQueryRefreshSchedule datasetDQRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshSchedule'>
        /// Update Refresh Schedule parameters, by specifying all or some of the
        /// parameters
        /// </param>
        public static void UpdateRefreshSchedule(this IDatasetsOperations operations, Guid groupId, string datasetId, RefreshSchedule datasetModelRefreshSchedule)
        {
            operations.UpdateRefreshScheduleInGroupAsync(groupId, datasetId, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetModelRefreshSchedule'>
        /// Update Refresh Schedule parameters, by specifying all or some of the
        /// parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateRefreshScheduleAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, RefreshSchedule datasetModelRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, new RefreshScheduleRequest { Value = datasetModelRefreshSchedule }, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshSchedule'>
        /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
        /// specifying all or some of the parameters
        /// </param>
        public static void UpdateDirectQueryRefreshSchedule(this IDatasetsOperations operations, Guid groupId, string datasetId, DirectQueryRefreshSchedule datasetDQRefreshSchedule)
        {
            operations.UpdateDirectQueryRefreshScheduleInGroupAsync(groupId, datasetId, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='datasetDQRefreshSchedule'>
        /// Patch DirectQuery or LiveConnection Refresh Schedule parameters, by
        /// specifying all or some of the parameters
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateDirectQueryRefreshScheduleAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, DirectQueryRefreshSchedule datasetDQRefreshSchedule, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateDirectQueryRefreshScheduleInGroupWithHttpMessagesAsync(groupId, datasetId, new DirectQueryRefreshScheduleRequest { Value = datasetDQRefreshSchedule }, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// </param>
        public static MashupParameters GetParameters(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.GetParametersInGroupAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<MashupParameters> GetParametersAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.GetParametersInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='updateMashupParametersRequest'>
        /// </param>
        public static void UpdateParameters(this IDatasetsOperations operations, Guid groupId, string datasetId, UpdateMashupParametersRequest updateMashupParametersRequest)
        {
            operations.UpdateParametersInGroupAsync(groupId, datasetId, updateMashupParametersRequest).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// </param>
        /// <param name='updateMashupParametersRequest'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateParametersAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, UpdateMashupParametersRequest updateMashupParametersRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateParametersInGroupWithHttpMessagesAsync(groupId, datasetId, updateMashupParametersRequest, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        /// <summary>
        /// Updates the value for external sharing setting for the specified dataset
        /// from the specified workspace.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='updateInPlaceSharingRequest'>
        /// </param>
        public static void UpdateInPlaceSharing(this IDatasetsOperations operations, System.Guid groupId, System.Guid datasetId, UpdateInPlaceSharingRequest updateInPlaceSharingRequest)
        {
            operations.UpdateInPlaceSharingInGroupAsync(groupId, datasetId, updateInPlaceSharingRequest).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Updates the value for external sharing setting for the specified dataset
        /// from the specified workspace.
        /// </summary>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='updateInPlaceSharingRequest'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task UpdateInPlaceSharingAsync(this IDatasetsOperations operations, System.Guid groupId, System.Guid datasetId, UpdateInPlaceSharingRequest updateInPlaceSharingRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await operations.UpdateInPlaceSharingInGroupWithHttpMessagesAsync(groupId, datasetId, updateInPlaceSharingRequest, null, cancellationToken).ConfigureAwait(false)).Dispose();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        public static Gateways DiscoverGateways(this IDatasetsOperations operations, Guid groupId, string datasetId)
        {
            return operations.DiscoverGatewaysInGroupAsync(groupId, datasetId).GetAwaiter().GetResult();
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
        /// <param name='datasetId'>
        /// The dataset id
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<Gateways> DiscoverGatewaysAsync(this IDatasetsOperations operations, Guid groupId, string datasetId, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.DiscoverGatewaysInGroupWithHttpMessagesAsync(groupId, datasetId, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Executes Data Analysis Expressions (DAX) queries against the provided
        /// dataset. The dataset must reside in a [new workspace
        /// experience](/power-bi/collaborate-share/service-new-workspaces) workspace.
        /// </summary>
        /// <remarks>
        ///
        /// DAX query errors will result in:
        ///
        /// - A response error, such as `DAX query failure`.
        /// - A failure HTTP status code (400).
        ///
        /// A query that requests more than one table, or more than the allowed number
        /// of table rows, will result in:
        ///
        /// - Limited data being returned.
        /// - A response error, such as `More than one result table in a query` or
        /// `More than {allowed number} rows in a query result`.
        /// - A successful HTTP status code (200).
        ///
        /// Columns that are fully qualified in the query will be returned with a fully
        /// qualified name, for example, `MyTable[MyColumn]`. Columns that are renamed
        /// or created in the query will be returned within square bracket, for
        /// example, `[MyNewColumn]`.
        ///
        /// ## Permissions
        ///
        /// The user must have [Manage dataset access
        /// permissions](/power-bi/connect-data/service-datasets-manage-access-permissions).
        ///
        /// ## Required Scope
        ///
        /// Dataset.ReadWrite.All or Dataset.Read.All
        ///
        /// ## Limitations
        ///
        /// - Only datasets in a [new workspace
        /// experience](/power-bi/collaborate-share/service-new-workspaces) workspace,
        /// that is to say a **V2** workspace, are supported.
        /// - Datasets that are hosted in Azure Analysis Services or that have a live
        /// connection to an on-premises Azure Analysis Services model aren't
        /// supported.
        /// - The tenant setting **Dataset Execute Queries REST API**, found under
        /// **Integration settings**, must be enabled.
        /// - One query per API call.
        /// - One table request per query.
        /// - Maximum of 100,000 rows or 1,000,000 values per query (whichever is hit
        /// first). For example if you query for 5 columns, you can get back max
        /// 100,000 rows. If you query for 20 columns, you can get back max 50,000 rows
        /// (1 million divided by 20).
        /// - Service Principals aren't supported for datasets with RLS per [RLS
        /// limitations](/power-bi/admin/service-admin-rls#considerations-and-limitations) or with SSO enabled.
        /// &lt;br&gt;&lt;br&gt;
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='requestMessage'>
        /// The request message
        /// </param>
        public static DatasetExecuteQueriesResponse ExecuteQueries(this IDatasetsOperations operations, System.Guid groupId, string datasetId, DatasetExecuteQueriesRequest requestMessage)
        {
            return operations.ExecuteQueriesAsync(groupId, datasetId, requestMessage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Executes Data Analysis Expressions (DAX) queries against the provided
        /// dataset. The dataset must reside in a [new workspace
        /// experience](/power-bi/collaborate-share/service-new-workspaces) workspace.
        /// </summary>
        /// <remarks>
        ///
        /// DAX query errors will result in:
        ///
        /// - A response error, such as `DAX query failure`.
        /// - A failure HTTP status code (400).
        ///
        /// A query that requests more than one table, or more than the allowed number
        /// of table rows, will result in:
        ///
        /// - Limited data being returned.
        /// - A response error, such as `More than one result table in a query` or
        /// `More than {allowed number} rows in a query result`.
        /// - A successful HTTP status code (200).
        ///
        /// Columns that are fully qualified in the query will be returned with a fully
        /// qualified name, for example, `MyTable[MyColumn]`. Columns that are renamed
        /// or created in the query will be returned within square bracket, for
        /// example, `[MyNewColumn]`.
        ///
        /// ## Permissions
        ///
        /// The user must have [Manage dataset access
        /// permissions](/power-bi/connect-data/service-datasets-manage-access-permissions).
        ///
        /// ## Required Scope
        ///
        /// Dataset.ReadWrite.All or Dataset.Read.All
        ///
        /// ## Limitations
        ///
        /// - Only datasets in a [new workspace
        /// experience](/power-bi/collaborate-share/service-new-workspaces) workspace,
        /// that is to say a **V2** workspace, are supported.
        /// - Datasets that are hosted in Azure Analysis Services or that have a live
        /// connection to an on-premises Azure Analysis Services model aren't
        /// supported.
        /// - The tenant setting **Dataset Execute Queries REST API**, found under
        /// **Integration settings**, must be enabled.
        /// - One query per API call.
        /// - One table request per query.
        /// - Maximum of 100,000 rows or 1,000,000 values per query (whichever is hit
        /// first). For example if you query for 5 columns, you can get back max
        /// 100,000 rows. If you query for 20 columns, you can get back max 50,000 rows
        /// (1 million divided by 20).
        /// - Service Principals aren't supported for datasets with RLS per [RLS
        /// limitations](/power-bi/admin/service-admin-rls#considerations-and-limitations) or with SSO enabled.
        /// &lt;br&gt;&lt;br&gt;
        /// </remarks>
        /// <param name='operations'>
        /// The operations group for this extension method.
        /// </param>
        /// <param name='groupId'>
        /// The workspace ID
        /// </param>
        /// <param name='datasetId'>
        /// The dataset ID
        /// </param>
        /// <param name='requestMessage'>
        /// The request message
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public static async Task<DatasetExecuteQueriesResponse> ExecuteQueriesAsync(this IDatasetsOperations operations, System.Guid groupId, string datasetId, DatasetExecuteQueriesRequest requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await operations.ExecuteQueriesInGroupWithHttpMessagesAsync(groupId, datasetId, requestMessage, null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }
    }
}
