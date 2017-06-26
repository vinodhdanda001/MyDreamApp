using System;
using System.Linq;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class RegisterDataService : IRegisterDataService
    {

        public void Register(RegisterModel registerModel)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                dbContext.Logins.Add(new Login
                {
                    userName = registerModel.UserName,
                    Organization_ID = registerModel.OrganizationId,
                    PasswordSalt = registerModel.Password, //TODO
                    PasswordHash = registerModel.Password, //TODO
                    LastUpdatedBy = registerModel.UserName,
                    IsActive = "Y",
                    cr_datetime = DateTime.Now,
                    updt_datetime = DateTime.Now
                });
                dbContext.SaveChanges();
            }

        }

        public bool IsRegistered(RegisterModel registerModel)
        {
            bool isRegistered = false;
            using (var dbContext = new TranportCatalogEntities())
            {
                isRegistered = dbContext.Logins.Where(t => t.Organization_ID == registerModel.OrganizationId
                                     && t.userName == registerModel.UserName
                                     //&& t.IsActive == "Y"
                                     ).Any();
            }
            return isRegistered;

        }
    }
}
