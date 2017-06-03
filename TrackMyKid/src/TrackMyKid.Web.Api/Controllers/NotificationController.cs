using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.Web.Api.Controllers
{
    public class NotificationController : ApiController
    {
        private readonly IMemberService _memberService;

        public NotificationController(IMemberService memberService)
        {
            if (memberService == null)
                throw new ArgumentNullException(nameof(memberService));

            _memberService = memberService;
        }

        [Route("api/notification/notifyotp")]
        [HttpPost]
        public HttpResponseMessage NotifyOtp(RegisterModel registerModel)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);

            if(_memberService.IsMemberExists(registerModel.organizationId, registerModel.primaryContactNum ))
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
