using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class TripModel
    {
        public string TripId  { get; set; }
        public string Route_ID { get; set; }
        public DateTime TripTime { get; set; }
        public int organizationId { get; set; }
        public int TripSessionID { get; set; }
        public string RouteID { get; set; }
        public string DriverId { get; set; }
        public int VehicleID { get; set; }
        public DateTime TripStartTime { get; set; }
        public DateTime TripEndTime { get; set; }
    }
}
