using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.DataLayer
{
    public class RouteService
    {
        public IEnumerable<Route> GetRoutesByOrg(int orgID)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var routes = dbContext.OrganizationRoutes.Where(t => t.Organization_ID == orgID)
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

        public Route GetRouteForMember(int orgID, string memberID)
        {
            using (var dbContext = new TranportCatalogEntities())
            {  
                    var routes = from route in dbContext.OrganizationRoutes
                                      join routeMember in dbContext.RouteMembers
                                                                    .Where(t => t.MemberID == memberID && t.Organization_ID == orgID)
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
    }
}
