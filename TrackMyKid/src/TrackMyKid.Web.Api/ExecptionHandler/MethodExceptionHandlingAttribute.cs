using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using TrackMyKid.Common.Helpers;


namespace TrackMyKid.Web.Api.ExecptionHandler
{
    public class MethodExceptionHandlingAttribute : ExceptionFilterAttribute
    {

        private static log4net.ILog log = //LogHelper.GetLogger();
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void PushToLog(CustomException e)
        {
            //log.Error(e.ErrorLogDetails);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {            
            if (actionExecutedContext.Exception is BusinessLayerException)
            {
                PushToLog(actionExecutedContext.Exception as BusinessLayerException);
                #region Business Exception
                var businessException = actionExecutedContext.Exception as BusinessLayerException;
                var errorMessagError = new System.Web.Http.HttpError(businessException.ErrorDescription) { { "ErrorCode", businessException.ErrorStatusCode } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);
                #endregion
            }
            else if (actionExecutedContext.Exception is DataLayerException)
            {
                PushToLog(actionExecutedContext.Exception as DataLayerException);
                #region DataException
                var dataException = actionExecutedContext.Exception as DataLayerException;
                var errorMessagError = new System.Web.Http.HttpError(dataException.ErrorDescription) { { "ErrorCode", dataException.ErrorStatusCode } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);
                #endregion
            }
            else if(actionExecutedContext.Exception is ApiLayerException)
            {
                PushToLog(actionExecutedContext.Exception as ApiLayerException);
                #region ApiException
                var apiException = actionExecutedContext.Exception as ApiLayerException;
                var errorMessagError = new System.Web.Http.HttpError(apiException.ErrorDescription) { { "ErrorCode", apiException.ErrorStatusCode } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);
                #endregion
            }
            else
            {
                var errorMessagError = new System.Web.Http.HttpError("Oops some internal Exception. Please contact your administrator") { { "ErrorCode", 500 } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError);
            }

        }


    }
}