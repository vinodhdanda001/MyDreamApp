using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.DataLayer;

namespace TrackMyKid.Web.Api.Controllers
{
    public class RouteController : ApiController
    {
        private static log4net.ILog log = //LogHelper.GetLogger();
                 log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //[Route("api/org/{orgId}/route")]
        //[HttpGet]
        //public IEnumerable<Route> GET(int orgId)
        //{
        //    log.Debug("Get: api/org/" + orgId.ToString());

        //    RouteService routeService = new RouteService();
        //    return routeService.GetRoutesByOrg(orgId);
        //}

        [Route("api/org/{orgId}/route/{memberID}")]
        [HttpGet]
        public Route GET(int orgId, string memberID)
        {
            log.Debug("Get: api/org/" + memberID);

            RouteService routeService = new RouteService();
            return routeService.GetRouteForMember(orgId, memberID);
        }

    }
}
