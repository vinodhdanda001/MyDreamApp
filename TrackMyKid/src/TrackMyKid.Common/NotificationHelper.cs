using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common
{
    public enum NotificationType
    {
        SMS
        ,EMAIL
        ,PUSH
    }
    public class NotificationBase
    {
        private NotificationType _notificationType;

        public NotificationBase(NotificationType notificationType )
        {
            _notificationType = notificationType;
        }
    }
}
