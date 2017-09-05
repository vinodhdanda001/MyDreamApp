using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TrackMyKid.Common.Models
{
    [Serializable]
    public class TripModel
    {  
        public TripModel()
        {

        }
        [JsonProperty("TripId")]
        public int TripId  { get; set; }
        //public string Route_ID { get; set; }
        [JsonProperty("TripTime")]
        public TimeSpan? TripTime { get; set; } //TODO
        [JsonProperty("organizationId")]
        public int organizationId { get; set; }
        [JsonProperty("TripSessionID")]
        public int TripSessionID { get; set; }
        [JsonProperty("RouteID")]
        public int RouteID { get; set; }
        [JsonProperty("DriverId")]
        public string DriverId { get; set; }
        [JsonProperty("VehicleID")]
        public int VehicleID { get; set; }
        [JsonProperty("TripStatusCd")]
        public TripStatusCode TripStatusCd { get; set; }

        [JsonProperty("TripStartTime")]
        [Column(TypeName = "datetime2")]
        public TimeSpan TripStartTime { get; set; }

        [JsonProperty("TripEndTime")]
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
