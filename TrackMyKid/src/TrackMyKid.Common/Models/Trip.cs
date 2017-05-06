using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class Trip
    {
        public string TripId  { get; set; }
        public string Route_ID { get; set; }
        public DateTime TripTime { get; set; }
    }
}
