using System.Collections.Generic;
using TrackMyKid.Common.Models;
using TrackMyKid.Common.ViewModel;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IHaltDataService
    {
        List<HaltModel> GetHaltsForRoute(int orgId, int routeId);

        List<HaltModel> GetHaltsForOrganization(int orgId);

        HaltModel AddHaltToOrganization(HaltModel halt);

        bool AddHaltsToRoute(OrganizationRouteHaltViewModel routehalts);
    }
}
