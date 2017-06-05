using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Web.Management.ApiHelper
{
    public class TripRestClient : ITripRestClient
    {
       

        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["webapibaseurl"];
        public TripRestClient()
        {
            _client = new RestClient(_url);
        }

        public List<TripModel> GetTripsForRoute(int orgId, int routeId)
        {
            var request = new RestRequest("api/org/" + orgId.ToString() + "/route/"+ routeId.ToString() +"/trips", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<TripModel>>(request);
            if (response.Data == null)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }

        public RouteModel AddRoute(RouteModel route)
        {
            var request = new RestRequest("api/route/add", Method.POST) { RequestFormat = DataFormat.Json, };
            request.AddBody(route);
            var response = _client.Execute<RouteModel>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }
    }
}