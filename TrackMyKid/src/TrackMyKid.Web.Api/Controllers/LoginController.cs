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
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        // POST api/books
        [Route("")]
        public HttpResponseMessage Post(LoginModel loginModel)
        {
            if (loginModel == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            LoginDataService loginService = new LoginDataService();
            UserProfile userProfile = loginService.Login(loginModel);
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
