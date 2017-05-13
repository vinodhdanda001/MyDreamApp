namespace TrackMyKid.Common
{

    public enum NotificationType
    {
      SMS
    , EMAIL
    , PUSH
    }
    interface INotificationHandler
    {
        void SendNotification();
        void AddRecipients();
    }
}
