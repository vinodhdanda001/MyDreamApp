using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
using log4net;
using TrackMyKid.DataLayer;
using System.Net.Http.Formatting;

namespace TrackMyKid.Web.Api.Controllers
{
    public class MemberController : ApiController
    {
        private static log4net.ILog log = //LogHelper.GetLogger();
                 log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Route("api/org/{orgId}/member/{id}")]
        [HttpGet]
        public HttpResponseMessage GET(int orgId, string id)
        {
            log.Debug("Get: api/org/" + orgId.ToString() + "/member/" + id.ToString());

            HttpResponseMessage response;
            Member member;
            MemberService memberService = new MemberService();
            member = memberService.GetMemberDetails(orgId, id);

            if(member == null)
            {
                response = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK , member, new JsonMediaTypeFormatter());
            }

            return response;
        }


        
        //public Member GET()
        //{
        //    return new Member
        //    {
        //        FirstName = "Vinodh",
        //        LastName = "Kumar"
        //    };
        //}

        
        //public Member GET(string id)
        //{
        //    return new Member
        //    {
        //        FirstName = "Danda",
        //        LastName = "Kumar"
        //    };
        //}
    }
}
