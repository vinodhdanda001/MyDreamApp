using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class TripModel
    {
        public int TripId  { get; set; }
        //public string Route_ID { get; set; }
        public DateTime TripTime { get; set; }
        public int organizationId { get; set; }
        public int TripSessionID { get; set; }
        public int RouteID { get; set; }
        public string DriverId { get; set; }
        public int VehicleID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TripStartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TripEndTime { get; set; }
    }

    public enum TripStatusCode
    {
        Invalid,
        InProgress,
        Completed
    }
}
