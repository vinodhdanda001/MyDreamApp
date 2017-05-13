using System;
using System.Linq;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Services
{
    public class TripDataService
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
                Organization_ID = trip.organizationId,
                LastUpdatedBy = trip.DriverId,
                Route_ID = trip.RouteID,
                TripId = trip.TripId,
                TripStatusCode = "I",
                cr_datetime = trip.TripStartTime,
                updt_datetime = trip.TripStartTime,
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

        public bool EndTrip(int tripSessionId)
        {
            bool isSuccess = false;
            using (var dbContext = new TranportCatalogEntities())
            {
                TripStatu tripStatus = dbContext.TripStatus.FirstOrDefault(t => t.TripSessionId == tripSessionId);
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

    }
}
