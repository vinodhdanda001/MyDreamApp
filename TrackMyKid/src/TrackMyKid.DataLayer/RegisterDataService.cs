using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer
{
    public class RegisterDataService
    {

        public void Register(RegisterModel registerModel)
        {
            using (var dbContext = new TranportCatalogEntities())
            {
                dbContext.Logins.Add(new Login
                {
                    userName = registerModel.userName,
                    Organization_ID = registerModel.organizationId,
                    PasswordSalt = "", //TODO
                    PasswordHash = "", //TODO
                    LastUpdatedBy = registerModel.userName,
                    IsActive = "Y",
                    cr_datetime = DateTime.Now,
                    updt_datetime = DateTime.Now
                });
                dbContext.SaveChanges();
            }

        }
    }
}
