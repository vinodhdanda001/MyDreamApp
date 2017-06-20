using System.Collections.Generic;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface ITripDataService
    {
        int StartTrip(TripModel trip);

        bool EndTrip(TripModel tripModel);

        TripModel CreateTrip(TripModel tripModel);

        TripStatusCode GetTripStatus(int tripSessionId);

        TripModel GetTripStatus(int orgId, int routeId, int tripId);

        List<TripModel> GetTripsForRoute(int orgId, int routeId);
    }
}
