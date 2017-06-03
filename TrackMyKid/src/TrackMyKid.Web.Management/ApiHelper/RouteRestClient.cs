using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Web.Management.ApiHelper
{
    public class RouteRestClient : IRouteRestClient
    {
        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["webapibaseurl"];
        public RouteRestClient()
        {
            _client = new RestClient(_url);
        }

        public List<Route> GetRoutesForOrg(int orgId)
        {
            var request = new RestRequest("api/org/"+ orgId.ToString() +"/route", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<Route>>(request);
            if (response.Data == null)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }
    }
}