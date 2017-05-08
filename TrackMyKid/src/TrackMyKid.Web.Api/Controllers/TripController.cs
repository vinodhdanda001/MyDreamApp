using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrackMyKid.Web.Api.Controllers
{
    public class TripController : ApiController
    {
        //In Progress
        private int SendOTPbySMS(int organizationId, int primaryContactNum)
        {
            int otp = 10;
            return otp;
        }
    }
}
