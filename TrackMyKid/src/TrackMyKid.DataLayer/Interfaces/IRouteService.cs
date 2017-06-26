using System.Collections.Generic;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IRouteService
    {
        IEnumerable<Route> GetRoutesByOrg(int orgId);

        Route GetRouteForMember(int orgId, string memberId);

        IEnumerable<TripModel> GetTripsForRoute(int orgId, string routeId);
    }
}
