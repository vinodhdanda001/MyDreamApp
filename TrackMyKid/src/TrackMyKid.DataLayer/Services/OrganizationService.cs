using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.DataLayer.Interfaces;

namespace TrackMyKid.DataLayer.Services
{
    public class OrganizationService : IOrganizationService
    {
        public bool IsOrgExists(int orgId)
        {
            bool isExists;
            
            using (var dbContext = new TranportCatalogEntities())
            {
                isExists = dbContext.Organizations.Where(t => t.Organization_ID == orgId
                                             && t.IsActive == "Y").Any();
            }
            return isExists;
        }
    }
}
