using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMyKid.Web.Management.Models;

namespace TrackMyKid.Web.Management.Controllers
{
    public class HelpController : Controller
    {
        private readonly string _url = ConfigurationManager.AppSettings["webapibaseurl"];
        // GET: Help
        public ActionResult Index()
        {
            ///api/org/100/trip/1001

            List<HelpModel> helpmodels = new List<HelpModel>();
            helpmodels.Add(new HelpModel { DisplayText = "Routes For Org", URL = _url + "api/org/100/route" });
            helpmodels.Add(new HelpModel { DisplayText = "Trips For Route", URL = _url + "api/org/100/trip/1001" });
            return View(helpmodels);
        }
    }
}