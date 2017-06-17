using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.ViewModel
{
    public class OrganizationRouteHaltViewModel
    {
        public int OrganizationId { get; set; }
        public int RouteId { get; set; }
        public List<RouteHaltModel> routeHalts { get; set; }
    }
}
