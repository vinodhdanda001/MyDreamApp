using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMyKid.Web.Management.ApiHelper
{
    public class GatewayRestClient
    {
        //private RestClient _client;
        //private RestRequest _request;

        public IRestResponse ExecuteApiRequest(RestClient client, RestRequest restRequest)
        {
            return client.Execute(restRequest);
        }

        public IRestResponse ExecuteApiRequest<T>(RestClient client, RestRequest restRequest) where T : new()
        {
            return client.Execute<T>(restRequest);
        }
    }
}