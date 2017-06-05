using System.Collections.Generic;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IRouteService
    {
        IEnumerable<RouteModel> GetRoutesByOrg(int orgId);
        RouteModel GetRouteForMember(int orgId, string memberId);
        IEnumerable<TripModel> GetTripsForRoute(int orgId, int routeId);
        RouteModel AddRoute(RouteModel route);
    }
}