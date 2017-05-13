using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;
using TrackMyKid.DataLayer.Services;

namespace TrackMyKid.Web.Api.Controllers
{
    public class TripController : ApiController
    {
        private readonly ITripDataService _tripDataService;

        public TripController(ITripDataService tripDataService)
        {
            if (tripDataService == null)
                throw new ArgumentNullException(nameof(tripDataService));

            _tripDataService = tripDataService;
        }

        [Route("api/trip/starttrip")]
        [HttpPost]
        public HttpResponseMessage StartTrip(TripModel trip) // int orgId, int primaryContactNo)
        {
            if (trip == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            int tripStatusId = -1;
            HttpResponseMessage response;
            tripStatusId = _tripDataService.StartTrip(trip);

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

        [Route("api/trip/endtrip/{tripStatusId}")]
        [HttpPost]
        public HttpResponseMessage EndTrip(int tripStatusId) // int orgId, int primaryContactNo)
        {
            HttpResponseMessage response;
            bool isEnded = false;
            isEnded = _tripDataService.EndTrip(tripStatusId);

            if (isEnded =_tripDataService.EndTrip(tripStatusId))
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
