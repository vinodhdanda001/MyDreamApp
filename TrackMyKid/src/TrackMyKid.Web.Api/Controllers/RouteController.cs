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
    public class RouteController : ApiController
    {
        private static log4net.ILog log = //LogHelper.GetLogger();
                 log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        
        [Route("api/org/{orgId}/route/{memberID}")]
        [HttpGet]
        public HttpResponseMessage GET(int orgId, string memberID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            log.Debug("Get: api/org/" + memberID);
            RouteService routeService = new RouteService();
            Route route = routeService.GetRouteForMember(orgId, memberID);
            if(route != null)
            {
                response.Content = new ObjectContent(typeof(Route), route, new JsonMediaTypeFormatter());
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
        public HttpResponseMessage GET(int orgId)
        {
            HttpResponseMessage response;
            log.Debug("Get: api/org/" +orgId.ToString() + "/route");
            RouteService routeService = new RouteService();
            IEnumerable<Route> routes = routeService.GetRoutesByOrg(orgId);
            if (routes != null && routes.Count() > 0)
            {
                response = Request.CreateResponse<IEnumerable<Route>>(HttpStatusCode.OK, routes);
                //response.Content = new ObjectContent(typeof(Route), route, new JsonMediaTypeFormatter());
                //response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
        }


        [Route("api/org/{orgId}/route/{routeID}/trips")]
        [HttpGet]
        public HttpResponseMessage GetTripsForRoute(int orgId, string routeID)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            log.Debug("api/org/"+orgId.ToString()+"/route/"+routeID.ToString()+"trips");
            RouteService routeService = new RouteService();
            IEnumerable<TripModel> trips = routeService.GetTripsForRoute(orgId, routeID);
            if (trips != null && trips.Count() > 0)
            {
                response = Request.CreateResponse<IEnumerable<TripModel>>(HttpStatusCode.OK, trips);
                //response.Content = new ObjectContent(typeof(Route), route, new JsonMediaTypeFormatter());
                //response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
        }


      

    }
}
