using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Web.Management.ApiHelper.Interfaces
{
    public interface IRouteRestClient
    {
        List<RouteModel> GetRoutesForOrg(int orgId);
        RouteModel AddRoute(RouteModel route);
    }
}