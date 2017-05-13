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

        public bool EndTrip(TripModel trip)  //int tripSessionID)
        {
            bool isSuccess = false;
            using (var dbContext = new TranportCatalogEntities())
            {
                TripStatu tripStatus = dbContext.TripStatus.Where(t =>
                 t.TripSessionId == trip.TripSessionID 
                 && t.TripStatusCode == "I").FirstOrDefault();
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
