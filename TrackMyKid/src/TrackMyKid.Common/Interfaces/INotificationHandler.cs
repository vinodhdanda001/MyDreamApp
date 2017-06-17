using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Interfaces
{

    public enum NotificationType
    {
      SMS
    , EMAIL
    , PUSH
    }
    interface INotificationHandler
    {
        void SendNotification(string _title, string _message);
        void AddRecipients(string _deviceID);
    }
}
