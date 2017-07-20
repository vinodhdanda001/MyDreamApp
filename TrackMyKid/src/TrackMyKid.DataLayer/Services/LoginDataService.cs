using System.Linq;
using TrackMyKid.Common.Helpers;
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
                if (!dbContext.Logins.Any(t => t.userName.Equals(loginModel.userName))) return null;
                {
                    var userProfile = from organizationMember in dbContext.OrganizationMembers
                            .Where(t => t.Organization_ID == loginModel.organizationId
                                        && t.userName == loginModel.userName)
                                      join routeMember in dbContext.RouteMembers
                                          .Where(t => t.Organization_ID == loginModel.organizationId)
                                      on organizationMember.MemberID equals routeMember.MemberID into profileDetails
                                      from profile in profileDetails.DefaultIfEmpty()
                                      select new UserProfile
                                      {
                                          UserName = organizationMember.userName,
                                          FirstName = organizationMember.FirstName,
                                          LastName = organizationMember.LastName,
                                          MiddleName = organizationMember.MiddleName,
                                          OrganizationId = organizationMember.Organization_ID,
                                          RouteID = profile.Route_ID,
                                          Address = organizationMember.Address
                                      };

                    return userProfile.FirstOrDefault();
                }
            }
        }

        public bool ValidateLogin(string username, string password)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                var userLoginEntity = dbContext.Logins.FirstOrDefault(t => t.userName.Equals(username));

                return userLoginEntity != null && 
                       PasswordUtils.Validate(password, userLoginEntity.PasswordHash, userLoginEntity.PasswordSalt);
            }
        }
    }
}
