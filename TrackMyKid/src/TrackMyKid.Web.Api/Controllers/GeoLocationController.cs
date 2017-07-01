using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;
using TrackMyKid.DataLayer.Services;

namespace TrackMyKid.Web.Api.Controllers
{
    public class GeoLocationController : ApiController
    {
        private readonly IGeoLocationService _geoLocationService;
        private readonly ITripDataService _tripDataService;

        public GeoLocationController(IGeoLocationService geoLocationService, ITripDataService tripDataService)
        {
            if (geoLocationService == null)
                throw new ArgumentNullException(nameof(geoLocationService));
            if (tripDataService == null)
                throw new ArgumentNullException(nameof(tripDataService));

            _geoLocationService = geoLocationService;
            _tripDataService = tripDataService;
        }

        [Route("api/geolocation/{tripSessionId}")]
        [HttpGet]
        public HttpResponseMessage GeoLocationBySession(int tripSessionId)
        {
            //Need to modify based on starus
            GeoLocation location;
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            TripStatusCode tripStatusCode = TripStatusCode.Invalid;

            tripStatusCode = _tripDataService.GetTripStatus(tripSessionId);

            if (tripStatusCode == TripStatusCode.Invalid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Trip. Can not provide location details");
            }
            else if (tripStatusCode == TripStatusCode.InProgress)
            {
                location = _geoLocationService.GetLocation(tripSessionId);
                if (location != null)
                {
                    response = Request.CreateResponse<GeoLocation>(HttpStatusCode.OK, location);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
            }
            else if (tripStatusCode == TripStatusCode.Completed)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid has been completed. Can not post location details");
            }
            return response;
        }

        [Route("api/geolocation/{orgId}/{routeId}/{tripId}")]
        [HttpGet]
        public HttpResponseMessage GeoLocationByTrip(int  orgId, int routeId, int tripId)
        {
            //Need to modify based on starus
            GeoLocation location;
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            TripModel tripmodel;

            tripmodel = _tripDataService.GetTripStatus(orgId, routeId, tripId);

            ////TODO    Not returning the proper returnset
            if (tripmodel != null)
            {
                if (tripmodel.TripStatusCd == TripStatusCode.InProgress)
                {
                    location = _geoLocationService.GetLocation(tripmodel.TripSessionID);
                    if (location != null)
                    {
                        response = Request.CreateResponse<GeoLocation>(HttpStatusCode.OK, location);
                    }
                    else
                    {
                        response = Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                }
                else //if (tripmodel.TripStatusCd == TripStatusCode.Completed)
                {
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, "Trip is not in progress. It may not be started or might be ended.");
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Can not provide the trip as it has not started");
            }

            
            return response;
        }




        [Route("api/geolocation")]
        public HttpResponseMessage POST(GeoLocation location)
        {
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            TripStatusCode tripStatusCode = TripStatusCode.Invalid;

            tripStatusCode = _tripDataService.GetTripStatus(location.TripSessionId);

            if(tripStatusCode == TripStatusCode.Invalid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Trip. Can not post location details");
            }
            else if(tripStatusCode == TripStatusCode.InProgress)
            {
                _geoLocationService.PutLocation(location);
                response = Request.CreateResponse<GeoLocation>(HttpStatusCode.OK, location);
            }
            else if(tripStatusCode == TripStatusCode.Completed)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid has been completed. Can not post location details");
            }
            return response;
        }
    }
}
