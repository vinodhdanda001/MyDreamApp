using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;
using TrackMyKid.Web.Management.ApiHelper.Interfaces;
using Newtonsoft.Json;
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

        //public string GetTripsForRoute(int orgId, int routeId)
        public List<TripModel> GetTripsForRoute(int orgId, int routeId)
        {

            ////http://localhost:58735/api/org/100/trip/1001
            var request = new RestRequest("api/org/" + orgId.ToString() + "/trip/" + routeId.ToString(), Method.GET) { RequestFormat = DataFormat.Json };
            //var response = _client.Execute<List<TripModel>>(request);
            var response = _client.Execute(request);
            string str = response.Content;
            List<TripModel> trips = JsonConvert.DeserializeObject<List<TripModel>>(str);

            //return response.Data
                return trips;
        }

        public TripModel AddTrip(TripModel trip)
        {
            //api/org/{orgId}/trip/create
            var request = new RestRequest("api/trip/add", Method.POST) { RequestFormat = DataFormat.Json

            };
            var jsonStr = JsonConvert.SerializeObject(trip);
            request.AddBody(jsonStr);
            var response = _client.Execute<TripModel>(request);

            if (response.Data == null)
                throw new Exception(response.ErrorMessage);
            return response.Data;
        }
    }
}