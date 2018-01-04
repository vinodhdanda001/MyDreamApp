using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TrackMyKid.NotificationManager.Exceptions
{
    public class FCMUnauthorizedException: FCMException
    { 

        public FCMUnauthorizedException():base(HttpStatusCode.Unauthorized, "Unauthorized")
        {
            
        }
    }
}
