using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.Web.Api.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly IMemberService _memberService;
        private readonly IRegisterDataService _registerDataService;
        private readonly ILoginDataService _loginDataService;

        public RegisterController(
            IRegisterDataService registerDataService, 
            IMemberService memberService, 
            ILoginDataService loginDataService)
        {
            if (registerDataService == null)
                throw new ArgumentNullException(nameof(registerDataService));
            if (memberService == null)
                throw new ArgumentNullException(nameof(memberService));
            if (loginDataService == null)
                throw new ArgumentNullException(nameof(loginDataService));

            _registerDataService = registerDataService;
            _memberService = memberService;
            _loginDataService = loginDataService;
        }

        [Route("api/register")]
        public HttpResponseMessage Post(RegisterModel registerModel)
        {
            if (registerModel == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            HttpResponseMessage response;
            // Prepae the Hash Key  -- TODO

            if (!_registerDataService.IsRegistered(registerModel))
            {
                _registerDataService.Register(registerModel);
                UserProfile userProfile = _loginDataService.Login(new LoginModel
                {
                    userName = registerModel.UserName,
                    passWord = registerModel.Password,
                    organizationId = registerModel.OrganizationId
                });
                if (userProfile != null)
                {
                    response = Request.CreateResponse<UserProfile>(HttpStatusCode.OK, userProfile, new JsonMediaTypeFormatter());
                }
                else
                    response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "User already registered");
            }
            return response;
        }

        [Route("api/register/validateandsendotp")]
        [HttpPost]
        public HttpResponseMessage ValidateAndSendOTP(RegisterModel registerModel) // int orgId, int primaryContactNo)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);

            if(_memberService.IsMemberExists(registerModel.OrganizationId, registerModel.PrimaryContactNum))
            {
                int otp = SendOTPbySMS(registerModel.OrganizationId, registerModel.PrimaryContactNum);
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
