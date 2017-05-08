using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer;

namespace TrackMyKid.Web.Api.Controllers
{
    public class TripController : ApiController
    {
       
        [Route("api/trip/starttrip")]
        [HttpPost]
        public HttpResponseMessage StartTrip(TripModel trip) // int orgId, int primaryContactNo)
        {
            int tripStatusId = -1;
            HttpResponseMessage response;
            TripDataService tripDataService = new TripDataService();
            tripStatusId = tripDataService.StartTrip(trip);
            if(tripStatusId == -1)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, tripStatusId);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }

        [Route("api/trip/endtrip/{tripStatusId}")]
        [HttpPost]
        public HttpResponseMessage EndTrip(int tripStatusId) // int orgId, int primaryContactNo)
        {
            HttpResponseMessage response;
            bool isEnded = false;
            TripDataService tripDataService = new TripDataService();
            isEnded = tripDataService.EndTrip(tripStatusId);
            if (isEnded = tripDataService.EndTrip(tripStatusId))
            {
                response = Request.CreateResponse(HttpStatusCode.OK, isEnded);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return response;
        }

    }
}
