using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
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


        [Route("api/org/{orgId}/route/{routeID}/halts")]
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


    }
}
