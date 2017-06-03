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
            if (trip == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            int tripStatusId = -1;
            HttpResponseMessage response;
            TripDataService tripDataService = new TripDataService();
            tripStatusId = tripDataService.StartTrip(trip);
            if(tripStatusId == -1)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, tripStatusId, new JsonMediaTypeFormatter());
            }

            return response;
        }

        [Route("api/trip/endtrip")]
        [HttpPost]
        public HttpResponseMessage EndTrip(TripModel trip) // int orgId, int primaryContactNo)
        {
            HttpResponseMessage response;
            bool isEnded = false;

            isEnded = _tripDataService.EndTrip(trip);
            if (isEnded)
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
