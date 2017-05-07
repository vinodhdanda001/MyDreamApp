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
    public class NotificationController : ApiController
    {
        private MemberService memberService;
        [Route("api/notification/notifyotp")]
        [HttpPost]
        public HttpResponseMessage NotifyOTP(RegisterModel registerModel)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            memberService = new MemberService();

            if(memberService.IsMemberExists(registerModel.organizationId, registerModel.primaryContactNum ))
            {

            }
            else
            {
                response.StatusCode = HttpStatusCode.Forbidden;
            }
            

            return response;

        }
    }
}
