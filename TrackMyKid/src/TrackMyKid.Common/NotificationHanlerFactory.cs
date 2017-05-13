namespace TrackMyKid.Common
{
    class NotificationHanlerFactory
    {
        static public INotificationHandler GetNotificationHandler(NotificationType notificationType)
        {
            INotificationHandler notificationHandler = null;
            switch(notificationType)
            {
                case NotificationType.SMS:
                                            notificationHandler = new SMSNotificationHandler();
                                            break;
                //case NotificationType.EMAIL:
                //                            notificationHandler = new EmailNotificationHandler();
                //                            break;
                case NotificationType.PUSH:
                                            notificationHandler = new PushNotificationHandler();
                                            break;

            }

            return notificationHandler;
        }
    }
}
