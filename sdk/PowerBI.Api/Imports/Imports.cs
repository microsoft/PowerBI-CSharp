using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api.V1.Models;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

namespace Microsoft.PowerBI.Api.V1
{
    /// <summary>
    /// Client wrapper for Power BI Imports REST Api
    /// </summary>
    public partial class Imports : IServiceOperations<PowerBIClient>, IImports
    {
        /// <summary>
        /// Uploads a PBIX file to the MyWorkspace
        /// </summary>
        /// <param name='file'>
        /// The PBIX file to import
        /// </param>
        /// <param name='datasetDisplayName'>
        /// The dataset display name
        /// </param>
        /// <param name='nameConflict'>
        /// Whether to overwrite dataset during conflicts
        /// </param>
        /// <param name="customHeaders">
        /// Optional custom headers
        /// </param>
        /// <param name="cancellationToken">
        /// Optional cancellation token
        /// </param>
        public async Task<HttpOperationResponse<Import>> PostImportFileWithHttpMessage(Stream file, string datasetDisplayName = default(string), string nameConflict = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PostImportFileWithHttpMessage(
							groupId: null,
							file: file,
							datasetDisplayName: datasetDisplayName,
							nameConflict: nameConflict,
							customHeaders: customHeaders,
							cancellationToken: cancellationToken);
        }
		
		/// <summary>
        /// Uploads a PBIX file to the specified group
        /// </summary>
        /// <param name='groupId'>
        /// The group Id
        /// </param>
        /// <param name='file'>
        /// The PBIX file to import
        /// </param>
        /// <param name='datasetDisplayName'>
        /// The dataset display name
        /// </param>
        /// <param name='nameConflict'>
        /// Whether to overwrite dataset during conflicts
        /// </param>
        /// <param name="customHeaders">
        /// Optional custom headers
        /// </param>
        /// <param name="cancellationToken">
        /// Optional cancellation token
        /// </param>
        public async Task<HttpOperationResponse<Import>> PostImportFileWithHttpMessage(string groupId, Stream file, string datasetDisplayName = default(string), string nameConflict = default(string), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {			
            if (file == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "file");
            }

            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("groupId", groupId ?? string.Empty);
                tracingParameters.Add("file", file);
                tracingParameters.Add("datasetDisplayName", datasetDisplayName);
                tracingParameters.Add("nameConflict", nameConflict);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PostImport", tracingParameters);
            }

			var groupsPart = (!string.IsNullOrEmpty(groupId)) ? "v1.0/myorg/groups/{groupId}/imports" : "v1.0/myorg/imports";
            var _baseUrl = this.Client.BaseUri.AbsoluteUri;
			var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), groupsPart).ToString();
			
			if (!string.IsNullOrEmpty(groupId))
			{
				_url = _url.Replace("{groupId}", Uri.EscapeDataString(groupId));
			}
            
            List<string> _queryParameters = new List<string>();
            if (datasetDisplayName != null)
            {
                _queryParameters.Add(string.Format("datasetDisplayName={0}", Uri.EscapeDataString(datasetDisplayName)));
            }
            if (nameConflict != null)
            {
                _queryParameters.Add(string.Format("nameConflict={0}", Uri.EscapeDataString(nameConflict)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += "?" + string.Join("&", _queryParameters);
            }

            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new Uri(_url);
            // Set Headers
            if (customHeaders != null)
            {
                foreach (var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            var multiPartContent = new MultipartFormDataContent();
            multiPartContent.Add(new StreamContent(file));

            _httpRequest.Content = multiPartContent;

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await this.Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 202) // Accepted
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, null);
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
            var _result = new HttpOperationResponse<Import>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 202) // Accepted
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<Import>(_responseContent, this.Client.DeserializationSettings);
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
