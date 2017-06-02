using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class RouteModel
    {
        public int OrganizationId { get; set; }
        public string RouteDisplayName { get; set; }
        public string EndHalt { get; set; }
        public int RouteId { get; set; }
    }
}
