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
                    userName = registerModel.userName,
                    Organization_ID = registerModel.organizationId,
                    PasswordSalt = registerModel.passWord, //TODO
                    PasswordHash = registerModel.passWord, //TODO
                    LastUpdatedBy = registerModel.userName,
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
                isRegistered = dbContext.Logins.Where(t => t.Organization_ID == registerModel.organizationId
                                     && t.userName == registerModel.userName
                                     //&& t.IsActive == "Y"
                                     ).Any();
            }
            return isRegistered;

        }
    }
}
