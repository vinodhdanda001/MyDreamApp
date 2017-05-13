using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.Web.Api.Controllers
{
    public class GeoLocationController : ApiController
    {
        private readonly IGeoLocationService _geoLocationService;

        public GeoLocationController(IGeoLocationService geoLocationService)
        {
            if (geoLocationService == null)
                throw new ArgumentNullException(nameof(geoLocationService));

            _geoLocationService = geoLocationService;
        }

        [Route("api/geolocation/{tripSessionId}")]
        [HttpGet]
        public HttpResponseMessage GeoLocation(int tripSessionId)
        {
            //Need to modify based on starus
            HttpResponseMessage response;
            var location = _geoLocationService.GetLocation(tripSessionId);

            if(location != null)
            {
                response = Request.CreateResponse<GeoLocation>(HttpStatusCode.OK, location);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return response;
        }

        [Route("api/geolocation")]
        public HttpResponseMessage POST(GeoLocation location)
        {
            HttpResponseMessage response;
            _geoLocationService.PutLocation(location);
            response = Request.CreateResponse(HttpStatusCode.OK, location);
            return response;
        }
    }
}
