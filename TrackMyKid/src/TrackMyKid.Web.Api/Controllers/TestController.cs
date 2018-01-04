using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrackMyKid.Web.Api.Controllers
{
    public class TestController : ApiController
    {

        [Route("api/org/{orgId}/test/test")]
        [HttpGet]
        public HttpResponseMessage GetHaltsForRoute()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            response = Request.CreateResponse("Hi Vinodh");
            return response;
        }

    }
}
