using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;
using TrackMyKid.Common.ViewModel;
using TrackMyKid.Web.Management.ApiHelper.Interfaces;

namespace TrackMyKid.Web.Management.ApiHelper
{
    public class HaltRestClient : IHaltRestClient
    {
        private readonly RestClient _client;
        private readonly string _url = ConfigurationManager.AppSettings["webapibaseurl"];
        public HaltRestClient()
        {
            _client = new RestClient(_url);
        }

        public bool AddHaltsToRoute(OrganizationRouteHaltViewModel routehalts)
        {   
            var request = new RestRequest("api/halt/addhalttoroute", Method.POST) { RequestFormat = DataFormat.Json, };
            request.AddBody(routehalts);
            var response = _client.Execute<bool>(request);
            return response.Data;
        }

        public HaltModel AddHaltToOrganization(HaltModel halt)
        {
            var request = new RestRequest("api/halt/add", Method.POST) { RequestFormat = DataFormat.Json, };
            request.AddBody(halt);
            var response = _client.Execute<HaltModel>(request);
            return response.Data;
        }

        public List<HaltModel> GetHaltsForOrganization(int orgId)
        {
            var request = new RestRequest("api/org/"+ orgId.ToString()+"/halt", Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<HaltModel>>(request);
            return response.Data;
        }

        public List<HaltModel> GetHaltsForRoute(int orgId, int routeId)
        {
            var request = new RestRequest("api/org/" + orgId.ToString() + "/halt/" + routeId.ToString(), Method.GET) { RequestFormat = DataFormat.Json };
            var response = _client.Execute<List<HaltModel>>(request);
            return response.Data;
        }
    }
}