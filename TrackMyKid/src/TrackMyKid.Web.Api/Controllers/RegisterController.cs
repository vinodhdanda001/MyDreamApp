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
            HttpResponseMessage response;
            RegisterDataService registerService = new RegisterDataService();
            // Prepae the Hash Key  -- TODO
            registerService.Register(registerModel);

            LoginDataService loginService = new LoginDataService();
            UserProfile userProfile = loginService.Login(new LoginModel
            {
                 userName = registerModel.userName,
                 passWord = registerModel.passWord,
                 organizationId = registerModel.organizationId
            });
            if (userProfile != null)
            {
                response = Request.CreateResponse<UserProfile>(HttpStatusCode.OK, userProfile, new JsonMediaTypeFormatter());
            }   
            else
                response = Request.CreateResponse(HttpStatusCode.BadRequest);

            return response;
        }

        [Route("api/register/validateandsendotp")]
        [HttpPost]
        public HttpResponseMessage ValidateAndSendOTP(RegisterModel registerModel) // int orgId, int primaryContactNo)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            MemberService memberService = new MemberService();
            if(memberService.IsMemberExists(registerModel.organizationId, registerModel.primaryContactNum))
            {
                int otp = SendOTPbySMS(registerModel.organizationId, registerModel.primaryContactNum);
                response.Content = new ObjectContent(typeof(int), otp, new JsonMediaTypeFormatter());
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
