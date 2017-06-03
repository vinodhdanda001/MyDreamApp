using System;
using System.Collections.Generic;
using System.Linq;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class RouteService : IRouteService
    {
        public IEnumerable<Route> GetRoutesByOrg(int orgId)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var routes = dbContext.OrganizationRoutes.Where(t => t.Organization_ID == orgId)
                             .Select(t => new Route
                             {
                                 Organization_ID = t.Organization_ID,
                                 Route_ID = t.Route_ID,
                                 Route_Display_Name = t.Route_Display_Name,
                                 End_Halt = t.End_Halt
                             });
                return routes.ToList();
            }

        }

        public Route GetRouteForMember(int orgId, string memberId)
        {
            using (var dbContext = new TranportCatalogEntities())
            {  
                    var routes = from route in dbContext.OrganizationRoutes
                                      join routeMember in dbContext.RouteMembers
                                                                    .Where(t => t.MemberID == memberId && t.Organization_ID == orgId)
                                      on route.Route_ID equals routeMember.Route_ID
                                      select new Route
                                      {
                                          Organization_ID = route.Organization_ID,
                                          Route_ID = route.Route_ID,
                                          Route_Display_Name = route.Route_Display_Name,
                                          End_Halt = route.End_Halt
                                      };
                    return routes.FirstOrDefault();
            }

        }

        public IEnumerable<TripModel> GetTripsForRoute(int orgId, int routeId)
        {

            using (var dbContext = new TranportCatalogEntities())
            {
                var trips = from route in dbContext.OrganizationRoutes.Where(t=> t.IsActive.ToUpper() == "Y" 
                                                                                && t.Organization_ID == orgId
                                                                                && t.Route_ID == routeId)
                             join trip in dbContext.RouteTrips.Where(t => t.IsActive.ToUpper() == "Y" 
                                                                            && t.Organization_ID == orgId
                                                                            && t.Route_ID == routeId)
                                on route.Route_ID equals trip.Route_ID 
                             //join tripHalts in dbContext.RouteTrips.Where(t=> t.IsActive.ToUpper() == "Y"
                             //                                               && t.Organization_ID == orgId
                             //                                               && t.Route_ID.ToUpper() == routeID
                             //                                           )
                             //on route.Route_ID equals tripHalts.Route_ID
                             select new TripModel
                             {
                                 TripId = trip.TripId,
                                 RouteID = trip.Route_ID,
                                 TripTime = DateTime.MinValue   // To Do the timings has to be adjusted well
                             };
                return trips.ToList();
            }
        }

        public RouteModel AddRoute(RouteModel route)
        {
            return route;
        }
    }
}
