using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class RegisterModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public int organizationId { get; set; }
        public int primaryContactNum { get; set; }
<<<<<<< HEAD
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
=======
        public int mobileNumber { get; set; } // Previously not added --- added by bbb
>>>>>>> 52514947db310764db5af06d52d72b2e13842f19
    }
}
