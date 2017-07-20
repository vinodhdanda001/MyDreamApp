using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;
using static TrackMyKid.Common.Enums.Enumerations;

namespace TrackMyKid.Common.ViewModel
{
    public class NotificationViewModel
    {
        [Display(Name = "Route")]
        public List<RouteModel> routes { set; get; }

        [Display(Name = "Trip")]
        public List<TripModel> trips { set; get; }

        [Display(Name = "Notification Message")]
        public string Message { set; get; }

        public NotificationLevel notificationLevel;
        public int OrganizationId;
        public int RouteId;
        public int TripId;
        public string MemberIds;

        
    }
}
