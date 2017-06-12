using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class HaltDataService : IHaltDataService
    {
        public List<HaltModel> GetHaltsForRoute(int orgId, int routeId)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var halts = from halt in dbContext.RouteHalts
                                                               .Where(t => t.Organization_ID == orgId
                                                               && t.Route_ID == routeId
                                                               && t.IsActive == "Y")
                                  select new HaltModel
                                  {
                                      HaltName = halt.HaltName,
                                      Halt_Address = halt.Halt_Address,
                                      Seq_No = halt.Seq_No,
                                      X_Coordinate = halt.X_Coordinate,
                                      Y_Coordinate = halt.Y_Coordinate
                                  };
                return halts.ToList();
            }
        }
    }
}
