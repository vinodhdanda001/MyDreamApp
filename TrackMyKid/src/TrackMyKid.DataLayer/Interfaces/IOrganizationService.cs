using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IOrganizationService
    {
        bool IsOrgExists(int orgId);
    }
}
