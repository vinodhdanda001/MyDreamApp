using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.Web.Api.Controllers
{
    public class RouteController : ApiController
    {
        private static log4net.ILog log = //LogHelper.GetLogger();
                 log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            if (routeService == null)
                throw new ArgumentNullException(nameof(routeService));
           
            _routeService = routeService;
        }

        [Route("api/org/{orgId}/route/{memberID}")]
        [HttpGet]
        public HttpResponseMessage Get(int orgId, string memberId)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            log.Debug("Get: api/org/" + memberId);
            var route = _routeService.GetRouteForMember(orgId, memberId);

            if(route != null)
            {
                response.Content = new ObjectContent(typeof(RouteModel), route, new JsonMediaTypeFormatter());
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.StatusCode = HttpStatusCode.NoContent;
            }

            return response;
        }

        [Route("api/org/{orgId}/route")]
        [HttpGet]
        public HttpResponseMessage Get(int orgId)
        {
            HttpResponseMessage response;
            log.Debug("Get: api/org/" +orgId.ToString() + "/route");
            var routes = _routeService.GetRoutesByOrg(orgId).ToList();

            if(routes.Any())
            {
                response = Request.CreateResponse<IEnumerable<RouteModel>>(HttpStatusCode.OK, routes);
                //response.Content = new ObjectContent(typeof(Route), route, new JsonMediaTypeFormatter());
                //response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return response;
        }


        

        [Route("api/route/add")]
        [HttpPost]
        public HttpResponseMessage AddRoute(RouteModel route)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            route = _routeService.AddRoute(route);
            if(route.Route_ID > 0)
            {
                response = Request.CreateResponse<RouteModel>(HttpStatusCode.OK, route);
            }
            return response;
        }

    }
}
