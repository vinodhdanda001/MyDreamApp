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
        private readonly IOrganizationService _organizationService;

        public RouteController(IRouteService routeService, IOrganizationService organizationService)
        {
            if (routeService == null)
                throw new ArgumentNullException(nameof(routeService));

            if (organizationService == null)
                throw new ArgumentNullException(nameof(organizationService));

            _routeService = routeService;
            _organizationService = organizationService;
        }


        [Route("api/org/{orgId}/route/{memberID}")]
        [HttpGet]
        public HttpResponseMessage GET(int orgId, string memberID)
        {
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            log.Debug("Get: api/org/" + memberID);
            Route route = _routeService.GetRouteForMember(orgId, memberID);
            if (route != null)
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
            IEnumerable<Route> routes = _routeService.GetRoutesByOrg(orgId);
            
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
        public HttpResponseMessage GetTripsForRoute(int orgId, int routeID)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            log.Debug("api/org/"+orgId.ToString()+"/route/"+routeID.ToString()+"trips");
            IEnumerable<TripModel> trips = _routeService.GetTripsForRoute(orgId, routeID);
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

        [Route("api/org/{orgId}/route/add")]
        [HttpPost]
        public HttpResponseMessage AddRoute(RouteModel route)
        {
            log.Debug("api/org/{orgId}/route/add");
            HttpResponseMessage response=Request.CreateResponse(HttpStatusCode.NoContent) ;
            if (route == null)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
            if (_organizationService.IsOrgExists(route.OrganizationId))
            {
                route = _routeService.AddRoute(route);
                if(route.RouteId != 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK,route);
                }
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, "Oranazation doesnot exist");
            }
            return response;
        }




    }
}
