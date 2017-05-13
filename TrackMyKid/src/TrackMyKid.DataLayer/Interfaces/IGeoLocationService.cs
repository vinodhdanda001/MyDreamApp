using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IGeoLocationService
    {
        GeoLocation GetLocation(int tripSessionId);

        void PutLocation(GeoLocation location);
    }
}
