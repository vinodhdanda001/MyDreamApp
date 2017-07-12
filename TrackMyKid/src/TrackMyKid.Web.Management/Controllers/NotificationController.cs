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
    public class NotificationController : Controller
    {
        static readonly IRouteRestClient RouteRestClient = new RouteRestClient();
        static readonly INotificationRestClient NotificationRestClient = new NotificationRestClient();
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
                notificationLevel = nLevel,
                OrganizationId = orgId
            };

            if(nLevel == NotificationLevel.Route || nLevel == NotificationLevel.Trip)
            {
                notification.routes = RouteRestClient.GetRoutesForOrg(orgId);
                notification.trips = new List<TripModel>();
            }
            
            //TripRestClient.GetTripsForRoute(orgId, routeId);
            return View(notification);
        }

        [HttpPost]
        public ActionResult Index(NotificationViewModel notification)
        {
            if(notification.notificationLevel == NotificationLevel.Organization)
            { }
            else if (notification.notificationLevel == NotificationLevel.Route)
            { }
            else if (notification.notificationLevel == NotificationLevel.Trip)
            { }
            else if (notification.notificationLevel == NotificationLevel.Member)
            { }
            return View(notification);
        }

        [HttpPost]
        public ActionResult GetTripsForRoute(int? rouetId , int? orgId)
        {
            if (rouetId != null && orgId != null)
            {
                List<TripModel> trips = TripRestClient.GetTripsForRoute((int)orgId, (int)rouetId);
                
                return Json(new { Success = "true", Data = trips });
            }
            return Json(new { Success = "false" });
        }



    }
}