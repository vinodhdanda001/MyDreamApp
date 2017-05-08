using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer
{
    public class TripDataService
    {

        public int StartTrip(TripModel trip)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                dbContext.TripStatus.Add(new TripStatu
                {
                    TripStartTime = trip.TripStartTime,
                    TripEndTime = trip.TripEndTime,
                    Driver_ID = trip.DriverId,
                    Organization_ID = trip.organizationId,
                    LastUpdatedBy = trip.DriverId,
                    Route_ID = trip.Route_ID,
                    TripId = trip.TripId,
                    TripStatusCode = "I",
                    cr_datetime = DateTime.Now,
                    Vehicle_ID = trip.VehicleID
                });
                dbContext.SaveChanges();
                return  trip.TripSessionID == 0 ?
                        -1 : trip.TripSessionID;

            }
        }

        public bool EndTrip(int tripSessionID)
        {
            bool isSuccess = false;
            using (var dbContext = new TranportCatalogEntities())
            {
                TripStatu tripStatus = dbContext.TripStatus.Where(t =>
                 t.TripSessionId == tripSessionID).FirstOrDefault();
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
