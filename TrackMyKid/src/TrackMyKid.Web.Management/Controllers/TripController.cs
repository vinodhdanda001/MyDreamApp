using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}