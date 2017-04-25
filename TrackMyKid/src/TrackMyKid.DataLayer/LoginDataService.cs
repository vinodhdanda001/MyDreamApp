using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer
{
    public class LoginDataService
    {

        public UserProfile Login(LoginModel loginModel)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                if(dbContext.Logins.Where(t=>t.userName.Equals(loginModel.userName)).Any())
                {
                    var userProfile = from orgMemeber in dbContext.OrganizationMembers
                                                                   .Where(t => t.Organization_ID == loginModel.organizationId && t.userName == loginModel.userName)
                                      join routeMember in dbContext.RouteMembers
                                                                    .Where(t => t.Organization_ID == loginModel.organizationId)
                                      on orgMemeber.MemberID equals routeMember.MemberID
                                      select new UserProfile
                                      {
                                          UserName = orgMemeber.userName,
                                          FirstName = orgMemeber.FirstName,
                                          LastName = orgMemeber.LastName,
                                          MiddleName = orgMemeber.MiddleName,
                                          OrganizationId = orgMemeber.Organization_ID,
                                          RouteID = routeMember.Route_ID,
                                          Address = orgMemeber.Address
                                      };
                }
                return null;

            }
        }

    }
}
