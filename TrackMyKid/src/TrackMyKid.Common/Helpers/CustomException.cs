using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TrackMyKid.Common.Enums;

namespace TrackMyKid.Common.Helpers
{
    public class CustomException : Exception
    {
        public CustomException()
        { }
        public CustomException(Exception e)
        {
            // Extract all the details and put into interlal error details log.
            if (!string.IsNullOrWhiteSpace(e.Message))
            {
                StringBuilder sbLogger = new StringBuilder("Log: Exception \n ================ \n Details \n ================ \n");
                sbLogger.AppendFormat("ErrorStatusCode {0} - ErrorStatusType - {1} - ErrorDescription {2}\n================ \n ", ErrorStatusCode, ErrorStatusType , ErrorDescription);
                sbLogger.AppendFormat("{0}\n{1}\n{2}\n{3}\n================ \n ", e.Message,e.Source,e.StackTrace,e.InnerException.Message);
                this.ErrorLogDetails = sbLogger.ToString();
            }
        }
        public virtual string ErrorStatusCode { get; set; }
        public virtual string ErrorStatusType { get; set; }
        //public virtual string ErrorStatusCode { get; set; }
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
            base.ErrorStatusCode = errorCode;
            base.ErrorDescription = errorDescription;
        }
        public ApiLayerException(Enumerations.eResponseStatusCode errorCode, string errorDescription, Exception e)
           : base(e)
        {
            base.ErrorStatusCode = ((int)errorCode).ToString();
            base.ErrorStatusType = errorCode.ToString();
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
            base.ErrorStatusCode = errorCode;
            base.ErrorDescription = errorDescription;
        }
        public BusinessLayerException(Enumerations.eResponseStatusCode errorCode, string errorDescription, Exception e)
           : base(e)
        {
            base.ErrorStatusCode = ((int)errorCode).ToString();
            base.ErrorStatusType = errorCode.ToString();
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
            base.ErrorStatusCode = errorCode;        
            base.ErrorDescription = errorDescription;
        }
        public DataLayerException(Enumerations.eResponseStatusCode errorCode, string errorDescription, Exception e)
          : base(e)
        {
            base.ErrorStatusCode = ((int)errorCode).ToString();
            base.ErrorStatusType = errorCode.ToString();
            base.ErrorDescription = errorDescription;
        }
    }

}