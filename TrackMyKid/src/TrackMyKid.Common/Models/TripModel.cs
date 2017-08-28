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
        public TimeSpan? TripTime { get; set; } //TODO
        public int organizationId { get; set; }
        public int TripSessionID { get; set; }
        public int RouteID { get; set; }
        public string DriverId { get; set; }
        public int VehicleID { get; set; }
        public TripStatusCode TripStatusCd { get; set; }

        [Column(TypeName = "datetime2")]
        public TimeSpan TripStartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public TimeSpan TripEndTime { get; set; }
    }

    public enum TripStatusCode
    {
        Invalid,
        InProgress,
        Completed
    }
}
