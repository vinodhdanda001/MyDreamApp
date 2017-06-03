using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Web.Management.ApiHelper
{
    public interface IRouteRestClient
    {
        List<Route> GetRoutesForOrg(int orgId);
    }
}