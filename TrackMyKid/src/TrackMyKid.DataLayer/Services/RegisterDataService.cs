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
                    userName = registerModel.Username,
                    Organization_ID = registerModel.OrganizationId,
                    PasswordSalt = registerModel.PasswordSalt,
                    PasswordHash = registerModel.PasswordHash,
                    LastUpdatedBy = registerModel.Username,
                    IsActive = "Y",
                    cr_datetime = DateTime.Now,
                    updt_datetime = DateTime.Now
                });
                dbContext.SaveChanges();
            }
        }

        public bool IsRegistered(RegisterModel registerModel)
        {
            bool isRegistered;
            using (var dbContext = new TranportCatalogEntities())
            {
                isRegistered = dbContext.Logins.Any(t => t.Organization_ID == registerModel.OrganizationId
                                                      && t.userName == registerModel.Username);
            }

            return isRegistered;
        }
    }
}
