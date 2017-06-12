using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Web.Management.ApiHelper
{
    public interface IHaltRestClient
    {
        List<TripModel> GetTripsForRoute(int orgId, int routeId);
        //TripModel AddTrip(TripModel tripModel);
    }
}