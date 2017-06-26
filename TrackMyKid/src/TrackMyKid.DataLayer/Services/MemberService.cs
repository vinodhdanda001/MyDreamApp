using System.Linq;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class MemberService : IMemberService
    {
        public Member GetMemberDetails(int orgId, string memberId)
        {
            try
            {

            }
            catch (System.Exception)
            {

                
            }
            using (var dbContext = new TranportCatalogEntities())
            {
                var userProfile = from orgMemeber in dbContext.OrganizationMembers
                                                               .Where(t => t.Organization_ID == orgId
                                                               && t.MemberID == memberId)
                                  join org in dbContext.Organizations
                                                                .Where(t => t.Organization_ID == orgId)
                                  on orgMemeber.Organization_ID equals org.Organization_ID
                                  select new Member
                                  {
                                      MemberId = orgMemeber.MemberID,
                                      OrganizationId = orgMemeber.Organization_ID,
                                      OrganizationName = org.Organization_Name,
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

        public bool IsMemberExists(int orgId, int mobileNum)
        {
            bool isMemberExists;

            using (var dbContext = new TranportCatalogEntities())
            {
                isMemberExists = (from orgMemeber in dbContext.OrganizationMembers
                                                              .Where(t => t.Organization_ID == orgId
                                                              && t.PrimaryContactNo == mobileNum
                                                              && t.IsActive.ToUpper() == "Y")
                                  join org in dbContext.Organizations
                                                                .Where(t => t.Organization_ID == orgId && t.IsActive.ToUpper() == "Y")
                                  on orgMemeber.Organization_ID equals org.Organization_ID
                                  select new Member
                                  {
                                      MemberId = orgMemeber.MemberID,
                                      OrganizationId = orgMemeber.Organization_ID,
                                      OrganizationName = org.Organization_Name,
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
                                  }).Any();
            }
            return isMemberExists;

        }
    }
}
