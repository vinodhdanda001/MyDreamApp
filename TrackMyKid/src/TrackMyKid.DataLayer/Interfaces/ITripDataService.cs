using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface ITripDataService
    {
        int StartTrip(TripModel trip);

        bool EndTrip(int tripSessionId);
    }
}
