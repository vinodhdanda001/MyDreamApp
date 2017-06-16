using TrackMyKid.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common
{
    class PushNotificationHandler : INotificationHandler
    {
        public List<string> toDeviceIDs;
        public void SMSNotification()
        {
            toDeviceIDs = new List<string>();
        }

        public void SendNotification(string _title, string _message)
        {

        }

        public void AddRecipients(string _deviceID)
        {
            toDeviceIDs.Add(_deviceID);
        }
    }
}
