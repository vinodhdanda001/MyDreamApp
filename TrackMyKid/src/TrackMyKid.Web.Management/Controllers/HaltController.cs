using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMyKid.Common.Models;
using TrackMyKid.Web.Management.ApiHelper;

namespace TrackMyKid.Web.Management.Controllers
{
    public class HaltController : Controller
    {

        static readonly IHaltRestClient RestClient = new HaltRestClient();
        private IHaltRestClient _restClient;
        // GET: Halt
        public ActionResult Index(int orgId, int routeId)
        {
            List<HaltModel> halts = RestClient.GetHaltsForRoute(orgId, routeId);
            ViewBag.HaltNames = halts;
            return View(halts);
        }

        //[ActionName("IndexOrg")]
        //public ActionResult Index(int orgId)
        //{
        //    return View(RestClient.GetHaltsForOrganization(orgId));
        //}
    }
}