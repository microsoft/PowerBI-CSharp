// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.PowerBI.Api
{
    using Microsoft.Rest;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// WorkspaceInfoOperations operations.
    /// </summary>
    public partial class WorkspaceInfoOperations : IServiceOperations<PowerBIClient>, IWorkspaceInfoOperations
    {
        /// <summary>
        /// Initializes a new instance of the WorkspaceInfoOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public WorkspaceInfoOperations(PowerBIClient client)
        {
            if (client == null)
            {
                throw new System.ArgumentNullException("client");
            }
            Client = client;
        }

        /// <summary>
        /// Gets a reference to the PowerBIClient
        /// </summary>
        public PowerBIClient Client { get; private set; }

        /// <summary>
        /// Initiates a call to receive metadata for the requested list of workspaces.
        /// </summary>
        /// <remarks>
        ///
        /// &gt; [!IMPORTANT]
        /// &gt; If you set the `datasetSchema` or `datasetExpressions` parameters to
        /// `true`, you must fully enable metadata scanning in order for data to be
        /// returned. For more information, see [Enable tenant settings for metadata
        /// scanning](/power-bi/admin/service-admin-metadata-scanning-setup#enable-tenant-settings-for-metadata-scanning).
        ///
        /// ## Permissions
        ///
        /// The user must have administrator rights (such as Microsoft 365 Global
        /// Administrator or Power BI Service Administrator) or authenticate using a
        /// service principal.
        ///
        /// ## Required Scope
        ///
        /// Tenant.Read.All or Tenant.ReadWrite.All
        ///
        /// ## Limitations
        ///
        /// - Maximum 500 requests per hour.
        /// - Maximum 16 simultaneous requests.
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='requiredWorkspaces'>
        /// Required workspace IDs to get info for
        /// </param>
        /// <param name='lineage'>
        /// Whether to return lineage info (upstream dataflows, tiles, data source IDs)
        /// </param>
        /// <param name='datasourceDetails'>
        /// Whether to return data source details
        /// </param>
        /// <param name='datasetSchema'>
        /// Whether to return dataset schema (tables, columns and measures). If you set
        /// this parameter to `true`, you must fully enable metadata scanning in order
        /// for data to be returned. For more information, see [Enable tenant settings
        /// for metadata
        /// scanning](/power-bi/admin/service-admin-metadata-scanning-setup#enable-tenant-settings-for-metadata-scanning).
        /// </param>
        /// <param name='datasetExpressions'>
        /// Whether to return dataset expressions (DAX and Mashup queries). If you set
        /// this parameter to `true`, you must fully enable metadata scanning in order
        /// for data to be returned. For more information, see [Enable tenant settings
        /// for metadata
        /// scanning](/power-bi/admin/service-admin-metadata-scanning-setup#enable-tenant-settings-for-metadata-scanning).
        /// </param>
        /// <param name='getArtifactUsers'>
        /// Whether to return user details for a Power BI item (such as a report or a
        /// dashboard)
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<ScanRequest>> PostWorkspaceInfoWithHttpMessagesAsync(RequiredWorkspaces requiredWorkspaces, bool? lineage = default(bool?), bool? datasourceDetails = default(bool?), bool? datasetSchema = default(bool?), bool? datasetExpressions = default(bool?), bool? getArtifactUsers = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (requiredWorkspaces == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "requiredWorkspaces");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("requiredWorkspaces", requiredWorkspaces);
                tracingParameters.Add("lineage", lineage);
                tracingParameters.Add("datasourceDetails", datasourceDetails);
                tracingParameters.Add("datasetSchema", datasetSchema);
                tracingParameters.Add("datasetExpressions", datasetExpressions);
                tracingParameters.Add("getArtifactUsers", getArtifactUsers);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PostWorkspaceInfo", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "v1.0/myorg/admin/workspaces/getInfo").ToString();
            List<string> _queryParameters = new List<string>();
            if (lineage != null)
            {
                _queryParameters.Add(string.Format("lineage={0}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(lineage, Client.SerializationSettings).Trim('"'))));
            }
            if (datasourceDetails != null)
            {
                _queryParameters.Add(string.Format("datasourceDetails={0}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(datasourceDetails, Client.SerializationSettings).Trim('"'))));
            }
            if (datasetSchema != null)
            {
                _queryParameters.Add(string.Format("datasetSchema={0}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(datasetSchema, Client.SerializationSettings).Trim('"'))));
            }
            if (datasetExpressions != null)
            {
                _queryParameters.Add(string.Format("datasetExpressions={0}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(datasetExpressions, Client.SerializationSettings).Trim('"'))));
            }
            if (getArtifactUsers != null)
            {
                _queryParameters.Add(string.Format("getArtifactUsers={0}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(getArtifactUsers, Client.SerializationSettings).Trim('"'))));
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            if(requiredWorkspaces != null)
            {
                _requestContent = Rest.Serialization.SafeJsonConvert.SerializeObject(requiredWorkspaces, Client.SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, System.Text.Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType =System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 202)
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<ScanRequest>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 202)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<ScanRequest>(_responseContent, Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Gets the scan status for the specified scan.
        /// </summary>
        /// <remarks>
        ///
        /// ## Permissions
        ///
        /// The user must have administrator rights (such as Microsoft 365 Global
        /// Administrator or Power BI Service Administrator) or authenticate using a
        /// service principal.
        ///
        /// ## Required Scope
        ///
        /// Tenant.Read.All or Tenant.ReadWrite.All
        ///
        /// ## Limitations
        ///
        /// Maximum 10,000 requests per hour.
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='scanId'>
        /// The scan ID, which is included in the response from the workspaces or
        /// getInfo API that triggered the scan
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<ScanRequest>> GetScanStatusWithHttpMessagesAsync(System.Guid scanId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("scanId", scanId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetScanStatus", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "v1.0/myorg/admin/workspaces/scanStatus/{scanId}").ToString();
            _url = _url.Replace("{scanId}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(scanId, Client.SerializationSettings).Trim('"')));
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<ScanRequest>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<ScanRequest>(_responseContent, Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Gets the scan result for the specified scan.
        /// </summary>
        /// <remarks>
        ///
        /// Only make this API call after a successful
        /// [GetScanStatus](/rest/api/power-bi/admin/workspace-info-get-scan-status)
        /// API call. The scan result will remain available for 24 hours.
        ///
        /// ## Permissions
        ///
        /// The user must have administrator rights (such as Microsoft 365 Global
        /// Administrator or Power BI Service Administrator) or authenticate using a
        /// service principal.
        ///
        /// ## Required Scope
        ///
        /// Tenant.Read.All or Tenant.ReadWrite.All
        ///
        /// ## Limitations
        ///
        /// Maximum 500 requests per hour.
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='scanId'>
        /// The scan ID, which is included in the response from the workspaces or
        /// getInfo API that triggered the scan
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<WorkspaceInfoResponse>> GetScanResultWithHttpMessagesAsync(System.Guid scanId, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("scanId", scanId);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetScanResult", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "v1.0/myorg/admin/workspaces/scanResult/{scanId}").ToString();
            _url = _url.Replace("{scanId}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(scanId, Client.SerializationSettings).Trim('"')));
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<WorkspaceInfoResponse>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<WorkspaceInfoResponse>(_responseContent, Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Gets a list of workspace IDs in the organization.
        /// </summary>
        /// <remarks>
        ///
        /// If the optional `modifiedSince` parameter is set to a date-time, only the
        /// IDs of workspaces that changed after that date-time are returned. If the
        /// `modifiedSince` parameter isn't used, the IDs of all workspaces in the
        /// organization are returned. The date-time specified by the `modifiedSince`
        /// parameter must be in the range of 30 minutes (to allow workspace changes to
        /// take effect) to 30 days prior to the current time.
        ///
        /// ## Permissions
        ///
        /// The user must have administrator rights (such as Microsoft 365 Global
        /// Administrator or Power BI Service Administrator) or authenticate using a
        /// service principal.
        ///
        /// ## Required Scope
        ///
        /// Tenant.Read.All or Tenant.ReadWrite.All
        ///
        /// ## Limitations
        ///
        /// Maximum 30 requests per hour.
        ///
        /// ######
        ///
        /// </remarks>
        /// <param name='modifiedSince'>
        /// Last modified date​ (must be in ISO 8601 compliant UTC format)
        /// </param>
        /// <param name='excludePersonalWorkspaces'>
        /// Whether to exclude personal workspaces​
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="HttpOperationException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<IList<ModifiedWorkspace>>> GetModifiedWorkspacesWithHttpMessagesAsync(System.DateTime? modifiedSince = default(System.DateTime?), bool? excludePersonalWorkspaces = default(bool?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("modifiedSince", modifiedSince);
                tracingParameters.Add("excludePersonalWorkspaces", excludePersonalWorkspaces);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetModifiedWorkspaces", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Client.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "v1.0/myorg/admin/workspaces/modified").ToString();
            List<string> _queryParameters = new List<string>();
            if (modifiedSince != null)
            {
                _queryParameters.Add(string.Format("modifiedSince={0}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(modifiedSince, Client.SerializationSettings).Trim('"'))));
            }
            if (excludePersonalWorkspaces != null)
            {
                _queryParameters.Add(string.Format("excludePersonalWorkspaces={0}", System.Uri.EscapeDataString(Rest.Serialization.SafeJsonConvert.SerializeObject(excludePersonalWorkspaces, Client.SerializationSettings).Trim('"'))));
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers


            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                if (_httpResponse.Content != null) {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                else {
                    _responseContent = string.Empty;
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<IList<ModifiedWorkspace>>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = Rest.Serialization.SafeJsonConvert.DeserializeObject<IList<ModifiedWorkspace>>(_responseContent, Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

    }
}
