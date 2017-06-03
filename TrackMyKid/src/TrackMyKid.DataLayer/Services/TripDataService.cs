using System;
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
            trip.TripStartTime = DateTime.Now;

            TripStatu tripStatus = new TripStatu
            {
                TripStartTime = DateTime.Now,
                TripEndTime = null,
                Driver_ID = trip.DriverId,
                Organization_ID = trip.OrganizationId,
                LastUpdatedBy = trip.DriverId,
                Route_ID = trip.RouteId,
                TripId = trip.TripId,
                TripStatusCode = "I",
                cr_datetime = trip.TripStartTime,
                updt_datetime = trip.TripStartTime,
                Vehicle_ID = trip.VehicleId
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
                var tripStatus = dbContext.TripStatus.FirstOrDefault(t => t.TripSessionId == trip.TripSessionId 
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
                if(tripStatus != null)
                {
                    if (tripStatus.TripStatusCode == "I")
                        tripStatusCode = TripStatusCode.InProgress;
                    else if (tripStatus.TripStatusCode == "C")
                        tripStatusCode = TripStatusCode.Completed;
                }
            }
            return tripStatusCode;
        }
    }
}
