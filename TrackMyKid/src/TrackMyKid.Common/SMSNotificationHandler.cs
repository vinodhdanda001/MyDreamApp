using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common
{
    public class SMSNotificationHandler : INotificationHandler
    {
        public List<int> toMobileNumers;
        public void SMSNotification()
        {
            toMobileNumers = new List<int>();
        }

        public void SendNotification()
        {
           
        }

        public void AddRecipients()
        {

        }
    }
}
