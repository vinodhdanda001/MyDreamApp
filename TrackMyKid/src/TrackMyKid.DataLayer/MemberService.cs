using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer
{
    public class MemberService
    {
        public Member GetMemberDetails(int orgId, string memberID)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var userProfile = from orgMemeber in dbContext.OrganizationMembers
                                                               .Where(t => t.Organization_ID == orgId
                                                               && t.MemberID == memberID)
                                  join org in dbContext.Organizations
                                                                .Where(t => t.Organization_ID == orgId)
                                  on orgMemeber.Organization_ID equals org.Organization_ID
                                  select new Member
                                  {
                                      MemberID = orgMemeber.MemberID,
                                      Organization_ID = orgMemeber.Organization_ID,
                                      Organization_Name = org.Organization_Name,
                                      UserName = orgMemeber.userName,
                                      FirstName = orgMemeber.FirstName,
                                      LastName = orgMemeber.LastName,
                                      MiddleName = orgMemeber.MiddleName,
                                      Address = orgMemeber.Address,
                                      AddressLandMark = orgMemeber.AddressLandMark,
                                      PinCode = orgMemeber.PinCode,
                                      Email = orgMemeber.Email,
                                      PrimaryContactNo = orgMemeber.PrimaryContactNo,
                                      AlternativeContactNo = orgMemeber.AlternativeContactNo
                                  };
                return userProfile.FirstOrDefault();
            }
        }
    }
}
