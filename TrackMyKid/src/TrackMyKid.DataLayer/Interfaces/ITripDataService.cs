using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface ITripDataService
    {
        int StartTrip(TripModel trip);

        bool EndTrip(TripModel tripModel);

        TripStatusCode GetTripStatus(int tripSessionId);
    }
}
