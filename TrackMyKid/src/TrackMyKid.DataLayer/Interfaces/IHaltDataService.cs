using System.Collections.Generic;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IHaltDataService
    {
        List<HaltModel> GetHaltsForRoute(int orgId, int routeId);
    }
}
