using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer
{
    public class GeoLocationService
    {   
        public GeoLocation GetLocation(int tripSessionId)
        {
            GeoLocation location;
            using (var dbContext = new TranportCatalogEntities())
            {
                location =  dbContext.TripGeoLocations.Where(t => t.TripSessionId == tripSessionId)
                                            .OrderByDescending(o => o.row_id)
                                            .Take(1)
                                            .Select(s => new GeoLocation
                                            {
                                                TripSessionId = s.TripSessionId,
                                                Lattitude = s.Lattitude,
                                                Longitude = s.Longitude
                                            }).FirstOrDefault();
            }
            return location;
        }

        public void PutLocation(GeoLocation location)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                dbContext.TripGeoLocations.Add(new TripGeoLocation
                {
                    TripSessionId = location.TripSessionId,
                    Lattitude = location.Lattitude,
                    Longitude = location.Longitude,
                    cr_datetime = DateTime.Now,
                    LastUpdatedBy = location.DriverID
                    
                });
                dbContext.SaveChanges();
            }
        }

       
    }
}
