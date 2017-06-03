using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View(RestClient.GetRoutesForOrg(100));
        }
    }
}