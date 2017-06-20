using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class LoginModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public int organizationId { get; set; }
        public string FcmTokenId { get; set; }
    }
}
