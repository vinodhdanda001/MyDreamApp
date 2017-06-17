using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMyKid.Common.Models;
using TrackMyKid.Web.Management.ApiHelper;

namespace TrackMyKid.Web.Management.Controllers
{
    public class RouteController : Controller
    {
        static readonly IRouteRestClient RestClient = new RouteRestClient();

        private IRouteRestClient _restClient;

        //public RouteController(IRouteRestClient restClient)
        //{
        //    _restClient = restClient;
        //}

        // GET: Route
        public ActionResult Index()
        {
            ViewBag.OrganizationID = 100;
            return View(RestClient.GetRoutesForOrg(100));
        }

        [HttpGet]
        public ActionResult Add()
        {
            RouteModel route = new RouteModel() { Organization_ID = 100 };    //TODO Initialize dynamically
            return View(route);
        }

        [HttpPost]
        public ActionResult Add(RouteModel route)
        {
            route = RestClient.AddRoute(route);
            if (route.Route_ID > 0)
            {
                return RedirectToAction("Index");
            }
            else
                return View(route);
        }
    }
}