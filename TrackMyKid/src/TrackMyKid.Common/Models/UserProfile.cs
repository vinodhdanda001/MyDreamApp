using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class UserProfile
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int OrganizationId { get; set; }
        public int RouteID { get; set; }
        public string RouteDisplayName { get; set; }
        public string TripId { get; set; }
        public string Address { get; set; }

        public string FullName {
                 get{
                          return FirstName + " " + LastName;    // MiddleName + " " +
            }
        }

        
  
                
                               
    }
}
