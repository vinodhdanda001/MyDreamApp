using System.Collections.Generic;

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
