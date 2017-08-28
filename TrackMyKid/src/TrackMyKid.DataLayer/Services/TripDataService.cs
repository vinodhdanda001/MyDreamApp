using System;
using System.Collections.Generic;
using System.Linq;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class TripDataService : ITripDataService
    {

        public int StartTrip(TripModel trip)
        {
            int tripSessionId = -1;
            trip.TripStartTime = DateTime.Now.TimeOfDay;

            TripStatu tripStatus = new TripStatu
            {
                TripStartTime = DateTime.Now,
                TripEndTime = null,
                Driver_ID = trip.DriverId,
                Organization_ID = trip.organizationId,
                LastUpdatedBy = trip.DriverId,
                Route_ID = trip.RouteID,
                TripId = trip.TripId,
                TripStatusCode = "I",
                cr_datetime = DateTime.Now, // trip.TripStartTime,
                updt_datetime = DateTime.Now,  //trip.TripStartTime,
                Vehicle_ID = trip.VehicleID
            };

            using (var dbContext = new TranportCatalogEntities())
            {
                dbContext.TripStatus.Add(tripStatus);

                dbContext.SaveChanges();
                tripSessionId = tripStatus.TripSessionId == 0 ?
                        -1 : tripStatus.TripSessionId;

            }
            return tripSessionId;
        }

        public bool EndTrip(TripModel trip)
        {
            bool isSuccess = false;
            using (var dbContext = new TranportCatalogEntities())
            {
                var tripStatus = dbContext.TripStatus.FirstOrDefault(t => t.TripSessionId == trip.TripSessionID
                 && t.TripStatusCode == "I");
                if (tripStatus != null)
                {
                    tripStatus.TripStatusCode = "C";
                    tripStatus.TripEndTime = DateTime.Now;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        public TripStatusCode GetTripStatus(int tripSessionId)
        {
            TripStatu tripStatus;
            TripStatusCode tripStatusCode = TripStatusCode.Invalid;
            using (var dbContext = new TranportCatalogEntities())
            {
                tripStatus = dbContext.TripStatus.Where(t => t.TripSessionId == tripSessionId).FirstOrDefault();
                if (tripStatus != null)
                {
                    if (tripStatus.TripStatusCode == "I")
                        tripStatusCode = TripStatusCode.InProgress;
                    else if (tripStatus.TripStatusCode == "C")
                        tripStatusCode = TripStatusCode.Completed;
                }
            }
            return tripStatusCode;
        }

        public List<TripModel> GetTripsForRoute(int orgId, int routeId)
        {

            using (var dbContext = new TranportCatalogEntities())
            {
                var trips = from route in dbContext.OrganizationRoutes.Where(t => t.IsActive.ToUpper() == "Y"
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
                                TripTime = (TimeSpan)trip.TripStartTime   // To Do the timings has to be adjusted well
                            };
                return trips.ToList();
            }
        }

        public TripModel CreateTrip(TripModel tripModel)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                int newTripId = dbContext.RouteTrips.Max(t => t.TripId)+1;
                tripModel.TripId = newTripId;

                dbContext.RouteTrips.Add(new RouteTrip
                {
                    Organization_ID = tripModel.organizationId,
                    Route_ID = tripModel.RouteID,
                    TripId = tripModel.TripId,
                    LastUpdatedBy = "Vinodh", // TODO
                    IsActive = "Y",
                    cr_datetime = DateTime.Now,
                    updt_datetime = DateTime.Now,
                    TripStartTime = tripModel.TripTime
                });

                dbContext.SaveChanges();

                return tripModel;
            }
        }

        public TripModel GetTripStatus(int orgId, int routeId, int tripId)
        {
            TripModel tripModel = null;
            TripStatu tripStatus;
            TripStatusCode tripStatusCode = TripStatusCode.Invalid;
            using (var dbContext = new TranportCatalogEntities())
            {
                tripStatus = dbContext.TripStatus.Where(t => t.Organization_ID == orgId
                    && t.Route_ID == routeId 
                    && t.TripId == tripId)
                    .OrderByDescending(t => t.TripStartTime)
                    .FirstOrDefault();
                if (tripStatus != null)
                {
                    if (tripStatus.TripStatusCode == "I")
                        tripStatusCode = TripStatusCode.InProgress;
                    else if (tripStatus.TripStatusCode == "C")
                        tripStatusCode = TripStatusCode.Completed;

                    tripModel = new TripModel
                    {
                        organizationId = orgId,
                        RouteID = routeId,
                        TripId = tripId,
                        TripSessionID = tripStatus.TripSessionId,
                        TripStatusCd = tripStatusCode
                    };
                }
                else
                {
                    tripModel = null;
                }   
            }
            return tripModel; ;
        }
    }
}
