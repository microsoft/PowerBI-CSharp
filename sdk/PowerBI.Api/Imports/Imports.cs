using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.PowerBI.Api.Beta
{
    public partial class Imports
    {
        public async Task<HttpOperationResponse<object>> PostImporFileWithHttpMessage(Stream file, string datasetDisplayName, int? nameConflict = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (datasetDisplayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "datasetDisplayName");
            }
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
                tracingParameters.Add("datasetDisplayName", datasetDisplayName);
                tracingParameters.Add("file", file);
                tracingParameters.Add("nameConflict", nameConflict);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PostImport", tracingParameters);
            }

            var _baseUrl = this.Client.BaseUri.AbsoluteUri;
            var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "beta/myorg/imports").ToString();
            List<string> _queryParameters = new List<string>();
            if (datasetDisplayName != null)
            {
                _queryParameters.Add(string.Format("datasetDisplayName={0}", Uri.EscapeDataString(datasetDisplayName)));
            }
            if (nameConflict != null)
            {
                _queryParameters.Add(string.Format("nameConflict={0}", Uri.EscapeDataString(SafeJsonConvert.SerializeObject(nameConflict, this.Client.SerializationSettings).Trim('"'))));
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
            var _result = new HttpOperationResponse<object>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 202) // Accepted
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<object>(_responseContent, this.Client.DeserializationSettings);
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
        public async Task<HttpOperationResponse<object>> PostImporFileByGroupWithHttpMessage(string group, Stream file, string datasetDisplayName, int? nameConflict = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (group == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "group");
            }
            if (file == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "file");
            }
            if (datasetDisplayName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "datasetDisplayName");
            }

            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("group", group);
                tracingParameters.Add("file", file);
                tracingParameters.Add("datasetDisplayName", datasetDisplayName);
                tracingParameters.Add("nameConflict", nameConflict);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PostImport", tracingParameters);
            }

            var _baseUrl = this.Client.BaseUri.AbsoluteUri;
            var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "beta/myorg/groups/{group}/imports").ToString();
            _url = _url.Replace("{group}", Uri.EscapeDataString(group));

            List<string> _queryParameters = new List<string>();
            if (datasetDisplayName != null)
            {
                _queryParameters.Add(string.Format("datasetDisplayName={0}", Uri.EscapeDataString(datasetDisplayName)));
            }
            if (nameConflict != null)
            {
                _queryParameters.Add(string.Format("nameConflict={0}", Uri.EscapeDataString(SafeJsonConvert.SerializeObject(nameConflict, this.Client.SerializationSettings).Trim('"'))));
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
            var _result = new HttpOperationResponse<object>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 202) // Accepted
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<object>(_responseContent, this.Client.DeserializationSettings);
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
