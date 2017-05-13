using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer;

namespace TrackMyKid.Web.Api.Controllers
{
    public class GeoLocationController : ApiController
    {
        [Route("api/geolocation/{tripSessionId}")]
        [HttpGet]
        public HttpResponseMessage GeoLocation(int tripSessionId)
        {
            //Need to modify based on starus
            GeoLocation location;
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            TripStatusCode tripStatusCode = TripStatusCode.Invalid;

            GeoLocationService locationService = new GeoLocationService();
            TripDataService tripDataService = new TripDataService();
            
            tripStatusCode = tripDataService.GetTripStatus(tripSessionId);

            if (tripStatusCode == TripStatusCode.Invalid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Trip. Can not provide location details");
            }
            else if (tripStatusCode == TripStatusCode.InProgress)
            {
                location = locationService.GetLocation(tripSessionId);
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

        [Route("api/geolocation")]
        public HttpResponseMessage POST(GeoLocation location)
        {
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            TripStatusCode tripStatusCode = TripStatusCode.Invalid;
            GeoLocationService locationService = new GeoLocationService();
            TripDataService tripDataService = new TripDataService();

            tripStatusCode = tripDataService.GetTripStatus(location.TripSessionId);

            if(tripStatusCode == TripStatusCode.Invalid)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Trip. Can not post location details");
            }
            else if(tripStatusCode == TripStatusCode.InProgress)
            {
                locationService.PutLocation(location);
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
