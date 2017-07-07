using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;
using static TrackMyKid.Common.Enums.Enumerations;

namespace TrackMyKid.Common.ViewModel
{
    public class NotificationViewModel
    {
        public NotificationLevel notificationLevel;
        public int RouteId;
        public int TripId;
        public string MemberIds;

        public List<RouteModel> routes;
        public List<TripModel> trips;
        public string Message;
    }
}
