using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Formatting;
using TrackMyKid.DataLayer.Interfaces;
using TrackMyKid.Common.Helpers;
using TrackMyKid.Common.Enums;

namespace TrackMyKid.Web.Api.Controllers
{
    public class MemberController : ApiController
    {
        private static log4net.ILog _log = //LogHelper.GetLogger();
                 log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            if (memberService == null)
                throw new ArgumentNullException(nameof(memberService));

            _memberService = memberService;
        }

        [Route("api/org/{orgId}/member/{id}")]
        [HttpGet]
        [ExecptionHandler.MethodExceptionHandling]
        public HttpResponseMessage GET(int orgId, string id)
        {
            _log.Debug("Get: api/org/" + orgId.ToString() + "/member/" + id.ToString());      
            HttpResponseMessage response = null as HttpResponseMessage;
            try
            {
                var member = _memberService.GetMemberDetails(orgId, id);
                if (member == null)
                {
                    response = Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, member, new JsonMediaTypeFormatter());
                }
            }
            catch (DataLayerException ex)
            {
                throw ex;
            }
            catch (BusinessLayerException ex)
            {
                throw ex;
            }
            catch (ApiLayerException ex)
            {
                throw ex;
            }            
            catch (Exception ex)
            {
                throw new ApiLayerException(Enumerations.eResponseStatusCode._API_LAYER_FAILURE, ex.Message,ex);                
            }
            finally
            {
                // need to configure centralized logging.
                //_log.Debug();
            }       
            return response;
        }
    }
}
