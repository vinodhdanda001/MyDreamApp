
namespace TrackMyKid.NotificationManager.Serialization
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISerializer
    {
        T Deserialize<T>(string json);
        string Serialize<T>(T value);
    }
}
