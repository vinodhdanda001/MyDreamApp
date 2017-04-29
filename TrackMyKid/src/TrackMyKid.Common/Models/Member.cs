using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class Member
    {
        public string MemberID { get; set; }
        public int Organization_ID { get; set; }
        public string Organization_Name { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string AddressLandMark { get; set; }
        public int PinCode { get; set; }
        public string Email { get; set; }
        public int PrimaryContactNo { get; set; }
        public int? AlternativeContactNo { get; set; }
    }
}
