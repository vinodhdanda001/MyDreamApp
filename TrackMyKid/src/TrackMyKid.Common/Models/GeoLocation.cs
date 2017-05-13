using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class GeoLocation
    {
        public int TripSessionId { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longitude { get; set; }
        public string DriverID { get; set; }
    }
}
