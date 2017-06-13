using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.PowerBI.Api.V2
{
    internal class ErrorHttpClientHandler : HttpClientHandler
    {
        readonly HttpClientHandler _httpClientHandler;

        public ErrorHttpClientHandler(HttpClientHandler httpClientHandler)
        {
            _httpClientHandler = httpClientHandler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Call the base class?
            var httpResponse = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (!httpResponse.IsSuccessStatusCode)
            {

            }

            return httpResponse;

        }
    }
}