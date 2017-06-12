using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.Web.Api.Controllers
{
    public class TripController : ApiController
    {
        private readonly ITripDataService _tripDataService;
        private static log4net.ILog _log = //LogHelper.GetLogger();
                 log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TripController(ITripDataService tripDataService)
        {
            if (tripDataService == null)
                throw new ArgumentNullException(nameof(tripDataService));

            _tripDataService = tripDataService;
        }

        //[Route("api/routes/{routeID}/trips")]
        //[HttpGet]
        //public HttpResponseMessage TripsForRoute(int routeID) // int orgId, int primaryContactNo)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.NoContent };

        //    List<TripModel> trips = _tripDataService.GetTripsForRoute(routeID);

        //    if (trips != null && trips.Count > 0)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.OK, trips, new JsonMediaTypeFormatter());
        //    }
        //    else
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //    return response;
        //}

        [Route("api/org/{orgId}/route/{routeID}/trip")]
        [HttpGet]
        public HttpResponseMessage GetTripsForRoute(int orgId, int routeID)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            _log.Debug("api/org/" + orgId.ToString() + "/route/" + routeID.ToString() + "trips");

            var trips = _tripDataService.GetTripsForRoute(orgId, routeID);

            if (trips != null && trips.Count > 0)
            {
                response = Request.CreateResponse<IEnumerable<TripModel>>(HttpStatusCode.OK, trips);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
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
