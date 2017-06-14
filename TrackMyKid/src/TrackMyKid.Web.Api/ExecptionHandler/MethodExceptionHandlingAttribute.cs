using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;


namespace TrackMyKid.Web.Api.ExecptionHandler
{
    public class MethodExceptionHandlingAttribute : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is BusinessLayerException)
            {
                #region Business Exception
                var businessException = actionExecutedContext.Exception as BusinessLayerException;
                var errorMessagError = new System.Web.Http.HttpError(businessException.ErrorDescription) { { "ErrorCode", businessException.ErrorCode } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);
                #endregion
            }
            else if (actionExecutedContext.Exception is DataLayerException)
            {
                #region DataException
                var dataException = actionExecutedContext.Exception as DataLayerException;
                var errorMessagError = new System.Web.Http.HttpError(dataException.ErrorDescription) { { "ErrorCode", dataException.ErrorCode } };
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessagError);
                #endregion
            }
            else if(actionExecutedContext.Exception is ApiLayerException)
            {
                #region ApiException
                var apiException = actionExecutedContext.Exception as ApiLayerException;
                var errorMessagError = new System.Web.Http.HttpError(apiException.ErrorDescription) { { "ErrorCode", apiException.ErrorCode } };
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