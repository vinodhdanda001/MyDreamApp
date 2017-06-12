using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrackMyKid.Web.Management.Controllers
{
    public class HaltController : Controller
    {
        // GET: Halt
        public ActionResult Index(int orgId, int routeId)
        {
            return View();
        }
    }
}