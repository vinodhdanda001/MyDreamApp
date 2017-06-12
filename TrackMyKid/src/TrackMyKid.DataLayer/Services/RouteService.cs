using System;
using System.Collections.Generic;
using System.Linq;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class RouteService : IRouteService
    {
        public IEnumerable<RouteModel> GetRoutesByOrg(int orgId)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var routes = dbContext.OrganizationRoutes.Where(t => t.Organization_ID == orgId)
                             .Select(t => new RouteModel
                             {
                                 Organization_ID = t.Organization_ID,
                                 Route_ID = t.Route_ID,
                                 Route_Display_Name = t.Route_Display_Name,
                                 End_Halt = t.End_Halt
                             });
                return routes.ToList();
            }

        }

        public RouteModel GetRouteForMember(int orgId, string memberId)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var routes = from route in dbContext.OrganizationRoutes
                             join routeMember in dbContext.RouteMembers
                                                           .Where(t => t.MemberID == memberId && t.Organization_ID == orgId)
                             on route.Route_ID equals routeMember.Route_ID
                             select new RouteModel
                             {
                                 Organization_ID = route.Organization_ID,
                                 Route_ID = route.Route_ID,
                                 Route_Display_Name = route.Route_Display_Name,
                                 End_Halt = route.End_Halt
                             };
                return routes.FirstOrDefault();
            }

        }

       
        public RouteModel AddRoute(RouteModel route)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var maxRouteId = dbContext.OrganizationRoutes.Select(t => t.Route_ID).Max();
                route.Route_ID = maxRouteId + 1;

                dbContext.OrganizationRoutes.Add(new OrganizationRoute
                {
                    Route_ID = route.Route_ID,
                    LastUpdatedBy = "Vinodh", // TODO
                    Organization_ID = route.Organization_ID,
                    Route_Display_Name = route.Route_Display_Name,
                    End_Halt = route.End_Halt,
                    cr_datetime = DateTime.Now,
                    IsActive = "Y",
                    updt_datetime = DateTime.Now
                });

                dbContext.SaveChanges();
            }
            return route;
        }
    }
}
