using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackMyKid.Common.Models
{
    public class TripModel
    {
        public string TripId  { get; set; }
        //public string Route_ID { get; set; }
        public DateTime TripTime { get; set; }
        public int organizationId { get; set; }
        public int TripSessionID { get; set; }
        public string RouteID { get; set; }
        public string DriverId { get; set; }
        public int VehicleID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TripStartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TripEndTime { get; set; }
    }
}
