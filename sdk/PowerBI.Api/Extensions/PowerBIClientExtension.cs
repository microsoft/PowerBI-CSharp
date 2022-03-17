using Microsoft.Rest;
using System;
using System.Linq;
using System.Net.Http;

namespace Microsoft.PowerBI.Api
{
    /// <summary>
    /// Partial class PowerBIClient adds new constructors to support using service principal profiles
    /// </summary>
    public partial class PowerBIClient : IPowerBIClient
    {
        // This header name will be added to apply the service principal profile to the API calls
        private readonly string c_servicePrincipalProfileHeaderName = "X-PowerBI-profile-id";

        /// <summary>
        /// Initializes a new instance of the PowerBIClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='profileObjectId'>
        /// Required. Service principal profile objectId.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public PowerBIClient(ServiceClientCredentials credentials, Guid profileObjectId, params DelegatingHandler[] handlers)
            : this(credentials, handlers)
        {
            HttpClient.DefaultRequestHeaders.Add(c_servicePrincipalProfileHeaderName, profileObjectId.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the PowerBIClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='profileObjectId'>
        /// Required. Service principal profile objectId.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public PowerBIClient(ServiceClientCredentials credentials, HttpClientHandler rootHandler, Guid profileObjectId, params DelegatingHandler[] handlers)
            : this(credentials, rootHandler, handlers)
        {
            HttpClient.DefaultRequestHeaders.Add(c_servicePrincipalProfileHeaderName, profileObjectId.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the PowerBIClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='profileObjectId'>
        /// Required. Service principal profile objectId.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public PowerBIClient(System.Uri baseUri, ServiceClientCredentials credentials, Guid profileObjectId, params DelegatingHandler[] handlers)
            : this(baseUri, credentials, handlers)
        {
            HttpClient.DefaultRequestHeaders.Add(c_servicePrincipalProfileHeaderName, profileObjectId.ToString());
        }

        /// <summary>
        /// Initializes a new instance of the PowerBIClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify client subscription.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='profileObjectId'>
        /// Required. Service principal profile objectId.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public PowerBIClient(System.Uri baseUri, ServiceClientCredentials credentials, HttpClientHandler rootHandler, Guid profileObjectId, params DelegatingHandler[] handlers)
            : this(baseUri, credentials, rootHandler, handlers)
        {
            HttpClient.DefaultRequestHeaders.Add(c_servicePrincipalProfileHeaderName, profileObjectId.ToString());
        }


        /// <inheritdoc/>
        public string GetServicePrincipalProfileObjectId()
        {
            if (HttpClient.DefaultRequestHeaders.TryGetValues(c_servicePrincipalProfileHeaderName, out var profileObjectIds))
            {
                return profileObjectIds.FirstOrDefault();
            }

            return null;
        }
    }
}
