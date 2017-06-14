using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMyKid.Common.Models;
using TrackMyKid.Web.Management.ApiHelper;

namespace TrackMyKid.Web.Management.Controllers
{
    public class TripController : Controller
    {

        static readonly ITripRestClient RestClient = new TripRestClient();

        private ITripRestClient _restClient;

        // GET: Trip
        public ActionResult Index(int orgId, int routeId)
        {
            return View(RestClient.GetTripsForRoute(orgId, routeId));
        }

        [HttpGet]
        public ActionResult Add(int orgId, int routeId)
        {
            TripModel trip = new TripModel
            {
                RouteID = routeId,
                organizationId = orgId
            };
            return View(trip);
        }

        [HttpPost]
        public ActionResult Add(TripModel trip)
        {
            trip = RestClient.AddTrip(trip);
            if (trip.TripId > 0)
            {
                return RedirectToAction("Index");
            }
            else
                return View(trip);
        }
    }
}