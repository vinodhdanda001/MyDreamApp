using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMyKid.Common.Models;
using TrackMyKid.Common.ViewModel;
using TrackMyKid.Web.Management.ApiHelper;
using TrackMyKid.Web.Management.ApiHelper.Interfaces;
using static TrackMyKid.Common.Enums.Enumerations;

namespace TrackMyKid.Web.Management.Controllers
{
    public class TrackingController : Controller
    {
        static readonly IRouteRestClient RouteRestClient = new RouteRestClient();
        static readonly INotificationRestClient NotificationRestClient = new NotificationRestClient();
        static readonly ITripRestClient TripRestClient = new TripRestClient();


        // GET: Tracking
        public ActionResult Index()
        {
           
            return View();
        }
    }
}