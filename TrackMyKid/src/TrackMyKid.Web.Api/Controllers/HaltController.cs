using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
using TrackMyKid.Common.ViewModel;
using TrackMyKid.DataLayer.Interfaces;
using TrackMyKid.DataLayer.Services;

namespace TrackMyKid.Web.Api.Controllers
{
    public class HaltController : ApiController
    {
        private readonly IHaltDataService _haltService;
        private static log4net.ILog _log = //LogHelper.GetLogger();
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HaltController( IHaltDataService haltDataService)
        {
            if (haltDataService == null)
                throw new ArgumentNullException(nameof(haltDataService));

            _haltService = haltDataService;
        }


        [Route("api/org/{orgId}/halt/{routeID}/")]
        [HttpGet]
        public HttpResponseMessage GetHaltsForRoute(int orgId, int routeID)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            _log.Debug("api/org/" + orgId.ToString() + "/route/" + routeID.ToString() + "halts");

            var halts = _haltService.GetHaltsForRoute(orgId, routeID);

            if (halts != null && halts.Count > 0)
            {
                response = Request.CreateResponse<IEnumerable<HaltModel>>(HttpStatusCode.OK, halts);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
        }

        [Route("api/org/{orgId}/halt")]
        [HttpGet]
        public HttpResponseMessage GetHaltsForOrganization(int orgId)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            _log.Debug("api/org/" + orgId.ToString() + "/halts");

            var halts = _haltService.GetHaltsForOrganization(orgId);

            if (halts != null && halts.Count > 0)
            {
                response = Request.CreateResponse<IEnumerable<HaltModel>>(HttpStatusCode.OK, halts);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
        }

        [Route("api/halt/add")]
        [HttpPost]
        public HttpResponseMessage AddHalt(HaltModel halt)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            //_log.Debug("api/org/" + orgId.ToString() + "/halts");

            halt = _haltService.AddHaltToOrganization(halt);

            if (halt != null && halt.HaltId > 0)
            {
                response = Request.CreateResponse<HaltModel>(HttpStatusCode.OK, halt);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return response;
        }

        [Route("api/halt/addhalttoroute")]
        [HttpPost]
        public HttpResponseMessage AddRouteHalt(OrganizationRouteHaltViewModel halts)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            //_log.Debug("api/org/" + orgId.ToString() + "/halts");

            bool isSuccess = _haltService.AddHaltsToRoute(halts);

            if (isSuccess)
            {
                response = Request.CreateResponse<bool>(HttpStatusCode.OK, true);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return response;
        }

    }
}
