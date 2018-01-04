using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TrackMyKid.NotificationManager.Exceptions
{

    /// <summary>
    /// 
    /// </summary>
    public class FCMException : Exception
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public FCMException(HttpStatusCode statusCode, string message)
            :base(message)
        {
            StatusCode = statusCode;
        }
        /// <summary>
        /// 
        /// </summary>
        public FCMException():base()
        {
        }

        /// <summary>
        /// The HttpStatusCode returned by FCM
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        
    }
}
