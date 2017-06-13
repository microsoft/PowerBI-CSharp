using System;
using System.Net.Http;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;

namespace Microsoft.PowerBI.Api.V2
{
    public partial class PowerBIClient
    {
        partial void CustomInitialize()
        {
            DeserializationSettings.Converters.Add(new PowerBIErrorJsonConverter());
            //HttpClient = new HttpClient(new ErrorHttpClientHandler(HttpClientHandler));
        }

        //Ideally, this would be done in the Call
        public PowerBIError GetError(Exception exception)
        {
            var http = exception as HttpOperationException;
            if(http?.Response?.Content != null)
                return SafeJsonConvert.DeserializeObject<PowerBIError>(http?.Response?.Content, DeserializationSettings);
            return null;
        }
    }
}