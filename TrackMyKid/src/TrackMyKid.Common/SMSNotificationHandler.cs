using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Interfaces;

namespace TrackMyKid.Common
{
    public class SMSNotificationHandler : INotificationHandler
    {
        public List<string> toMobileNumers;
        public void SMSNotification()
        {
            toMobileNumers = new List<string>();
        }

        public void SendNotification(string _title, string _message)
        {
           
        }

        public void AddRecipients(string _deviceID)
        {
            toMobileNumers.Add(_deviceID);
        }
    }
}
