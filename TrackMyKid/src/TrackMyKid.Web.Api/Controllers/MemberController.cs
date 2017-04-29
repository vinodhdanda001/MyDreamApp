using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackMyKid.Common.Models;
using log4net;
using TrackMyKid.DataLayer;

namespace TrackMyKid.Web.Api.Controllers
{
    public class MemberController : ApiController
    {
        private static log4net.ILog log = //LogHelper.GetLogger();
                 log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Route("api/org/{orgId}/member/{id}")]
        [HttpGet]
        public Member GET(int orgId, string id)
        {
            
            log.Debug("Get: api/org/" + orgId.ToString() + "/member/" + id.ToString());

            MemberService memberService = new MemberService();
            return memberService.GetMemberDetails(orgId, id);
            
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
