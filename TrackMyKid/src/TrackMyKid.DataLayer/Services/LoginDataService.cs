using System.Linq;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class LoginDataService : ILoginDataService
    {

        public UserProfile Login(LoginModel loginModel)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                if(dbContext.Logins.Where(t=>t.userName.Equals(loginModel.UserName)).Any())
                {
                    var userProfile = from orgMemeber in dbContext.OrganizationMembers
                                                                   .Where(t => t.Organization_ID == loginModel.OrganizationId 
                                                                            && t.userName == loginModel.UserName)
                                      join routeMember in dbContext.RouteMembers
                                                                    .Where(t => t.Organization_ID == loginModel.OrganizationId)
                                      on orgMemeber.MemberID equals routeMember.MemberID into profileDetails
                                      from profile in profileDetails.DefaultIfEmpty()
                                      select new UserProfile
                                      {
                                          UserName = orgMemeber.userName,
                                          FirstName = orgMemeber.FirstName,
                                          LastName = orgMemeber.LastName,
                                          MiddleName = orgMemeber.MiddleName,
                                          OrganizationId = orgMemeber.Organization_ID,
                                          RouteId = profile.Route_ID,
                                          Address = orgMemeber.Address
                                      };
                    return userProfile.FirstOrDefault();
                }
                return null;

            }
        }

    }
}
