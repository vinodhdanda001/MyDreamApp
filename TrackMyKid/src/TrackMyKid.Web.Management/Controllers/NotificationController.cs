using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackMyKid.Common.ViewModel;
using TrackMyKid.Web.Management.ApiHelper;
using static TrackMyKid.Common.Enums.Enumerations;

namespace TrackMyKid.Web.Management.Controllers
{
    public class NotificationController : Controller
    {
        static readonly IRouteRestClient RouteRestClient = new RouteRestClient();
        static readonly ITripRestClient TripRestClient = new TripRestClient();


        //// GET: Notification
        //public ActionResult Index()
        //{
        //    NotificationViewModel notification = new NotificationViewModel();
        //    return View(notification);
        //}

        // GET: Notification
        public ActionResult Index(NotificationLevel nLevel)
        {
            //orgID assign fom session
            int orgId = 100;

            NotificationViewModel notification = new NotificationViewModel()
            {
                notificationLevel = nLevel
            };

            if(nLevel == NotificationLevel.Route || nLevel == NotificationLevel.Trip)
            {
                notification.routes = RouteRestClient.GetRoutesForOrg(orgId);
            }
            
            //TripRestClient.GetTripsForRoute(orgId, routeId);
            return View(notification);
        }

        [HttpPost]
        public ActionResult Index(NotificationViewModel notification)
        {
            return View();
        }
    }
}