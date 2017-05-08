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
        public HttpResponseMessage GeoLocation(int tripSessionId)
        {
            //Need to modify based on starus
            GeoLocation location;
            HttpResponseMessage response;

            GeoLocationService locationService = new GeoLocationService();
            location = locationService.GetLocation(tripSessionId);
            if (location != null)
            {
                response = Request.CreateResponse<GeoLocation>(HttpStatusCode.OK, location);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }


            return response;
        }
    }
}
