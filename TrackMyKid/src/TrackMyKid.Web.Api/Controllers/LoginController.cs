using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.Web.Api.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private readonly ILoginDataService _loginDataService;

        public LoginController(ILoginDataService loginDataService)
        {
            if (loginDataService == null)
                throw new ArgumentNullException(nameof(loginDataService));

            _loginDataService = loginDataService;
        }

        [Route("")]
        public HttpResponseMessage Post(LoginModel loginModel)
        {
            if (loginModel == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var response = Request.CreateResponse(HttpStatusCode.NoContent);

            UserProfile userProfile = _loginDataService.Login(loginModel);
            if (userProfile != null)
            {
                response.Content = new ObjectContent(typeof(UserProfile), userProfile, new JsonMediaTypeFormatter());
                response.StatusCode = HttpStatusCode.OK;
            }
            else
                response.StatusCode = HttpStatusCode.Forbidden;

            return response;
        }
    }
}
