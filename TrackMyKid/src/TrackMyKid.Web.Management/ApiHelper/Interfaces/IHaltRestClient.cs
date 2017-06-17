using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;
using TrackMyKid.Common.ViewModel;

namespace TrackMyKid.Web.Management.ApiHelper
{
    public interface IHaltRestClient
    {
        List<HaltModel> GetHaltsForRoute(int orgId, int routeId);

        List<HaltModel> GetHaltsForOrganization(int orgId);

        HaltModel AddHaltToOrganization(HaltModel halt);

        bool AddHaltsToRoute(OrganizationRouteHaltViewModel routehalts);

    }
}