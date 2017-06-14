using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackMyKid.Web.Api.ExecptionHandler
{  
    public class CustomException : Exception
    {
        public CustomException()
        { }
        public CustomException(Exception e)
        {
            // Extract all the details and put into interlal error details log.
        }
        public virtual string ErrorCode { get; set; }
        public virtual string ErrorStatusCode { get; set; }
        public virtual string ErrorDescription { get; set; }
        public virtual string ErrorLogDetails { get; set; }
    }

    /// <summary>
    /// Use Status code 001
    /// </summary>
    public class ApiLayerException : CustomException
    {
        public ApiLayerException(string errorCode, string errorDescription, Exception e)
            : base(e)
        {
            base.ErrorCode = errorCode;
            base.ErrorDescription = errorDescription;
        }
    }
    /// <summary>
    /// Use Status code 002
    /// </summary>
    public class BusinessLayerException : CustomException
    {
        public BusinessLayerException(string errorCode, string errorDescription, Exception e)
            : base(e)
        {
            base.ErrorCode = errorCode;
            base.ErrorDescription = errorDescription;
        }
    }
    /// <summary>
    /// Use Status code 003
    /// </summary>
    public class DataLayerException : CustomException
    {
        public DataLayerException(string errorCode, string errorDescription, Exception e)
            : base(e)
        {
            base.ErrorCode = errorCode;
            base.ErrorDescription = errorDescription;
        }
    }
   
}