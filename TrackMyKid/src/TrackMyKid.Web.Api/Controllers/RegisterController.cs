using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer;

namespace TrackMyKid.Web.Api.Controllers
{
    public class RegisterController : ApiController
    {

        // POST api/books
        [Route("api/register")]
        public HttpResponseMessage Post(RegisterModel registerModel)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            LoginDataService loginService = new LoginDataService();
            UserProfile userProfile = loginService.Login(loginModel);
            if (userProfile != null)
                response.Content = new ObjectContent(typeof(UserProfile), userProfile, new JsonMediaTypeFormatter());
            else
                response.StatusCode = HttpStatusCode.Forbidden;

            return response;
        }

        [Route("api/register/validateandsendotp")]
        [HttpPost]
        public HttpResponseMessage ValidateAndAendOTP(RegisterModel registerModel) // int orgId, int primaryContactNo)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            MemberService memberService = new MemberService();
            if(memberService.IsMemberExists(registerModel.organizationId, registerModel.primaryContactNum))
            {
                int otp = SendOTPbySMS(registerModel.organizationId, registerModel.primaryContactNum);
                response.Content = new ObjectContent(typeof(UserProfile), otp, new JsonMediaTypeFormatter());
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.Forbidden;
                response.Content = new StringContent("Sorry. Your primary contact number is not registered with provided organization.");
            }
            return response;
        }

        private int SendOTPbySMS(int organizationId, int primaryContactNum)
        {
            int otp = 10;
            return otp;
        }
    }
}
