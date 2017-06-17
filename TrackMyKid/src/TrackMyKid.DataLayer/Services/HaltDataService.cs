using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;
using TrackMyKid.Common.ViewModel;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class HaltDataService : IHaltDataService
    {
        public List<HaltModel> GetHaltsForRoute(int orgId, int routeId)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var halts = from routehalt in dbContext.RouteHalts.Where(t => t.Organization_ID == orgId
                                                               && t.Route_ID == routeId
                                                               && t.IsActive == "Y")
                            join halt in dbContext.OrganizationHalts.Where(t => t.Organization_ID == orgId
                                                           && t.IsActive == "Y")
                                                           on routehalt.HaltID equals halt.HaltID
                            select new HaltModel
                            {
                                HaltName = halt.HaltName,
                                Halt_Address = halt.Halt_Address,
                                Seq_No = routehalt.Seq_No,
                                X_Coordinate = halt.X_Coordinate,
                                Y_Coordinate = halt.Y_Coordinate
                            };
                return halts.ToList();
            }
        }

        public List<HaltModel> GetHaltsForOrganization(int orgId)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var halts = from halt in dbContext.OrganizationHalts.Where(t => t.Organization_ID == orgId
                                                               && t.IsActive == "Y")
                            select new HaltModel
                            {
                                HaltName = halt.HaltName,
                                Halt_Address = halt.Halt_Address,
                                X_Coordinate = halt.X_Coordinate,
                                Y_Coordinate = halt.Y_Coordinate
                            };
                return halts.ToList();
            }
        }

        public HaltModel AddHaltToOrganization(HaltModel halt)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                int newHaltId = dbContext.OrganizationHalts.Max(t => t.HaltID) + 1;
                dbContext.OrganizationHalts.Add(new OrganizationHalt
                {
                    HaltID = newHaltId,
                    HaltName = halt.HaltName,
                    Halt_Address = halt.Halt_Address,
                    Organization_ID = halt.OrganizationId,
                    updt_datetime = DateTime.Now,
                    cr_datetime = DateTime.Now,
                    LastUpdatedBy = "Vinod", //Todo
                    IsActive = "Y"
                });
                dbContext.SaveChanges();
                halt.HaltId = newHaltId;

                return halt;
            }
        }

        public bool AddHaltsToRoute(OrganizationRouteHaltViewModel routehalts)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var rhalts = dbContext.RouteHalts.Where(t => t.Organization_ID == routehalts.OrganizationId
                && t.Route_ID == routehalts.RouteId && t.IsActive == "Y");

                dbContext.RouteHalts.RemoveRange(rhalts);

                var newHalts = from rh in routehalts.routeHalts
                               select new RouteHalt
                               {
                                   HaltID = rh.haltId,
                                   Organization_ID = routehalts.OrganizationId,
                                   Route_ID = routehalts.RouteId,
                                   Seq_No = rh.seqId,
                                   cr_datetime = DateTime.Now,
                                   updt_datetime = DateTime.Now,
                                   IsActive = "Y",
                                   LastUpdatedBy = "Vinodh" //TODO
                               };
                dbContext.RouteHalts.AddRange(newHalts);

                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
