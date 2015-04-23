using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ExceptionHandling;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NaGreen.WebApi.Infrastructure.ActionResults;
using System.Net;
using NaGreen.WebApi.Common.Exceptions;
using System.Web.Http;

namespace NaGreen.WebApi.Infrastructure.ExceptionHandlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;
            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new HttpErrorResult(context.Request,
                (HttpStatusCode)httpException.GetHttpCode(), httpException);
                return;
            }

            var nrgsException = exception as NaGreenWebException;
            if (nrgsException != null)
            {
                context.Result = new HttpErrorResult(context.Request,
                nrgsException.Error.HttpStatus, nrgsException);
                return;
            }

            var httpResponseException = exception as HttpResponseException;
            if (httpResponseException != null)
            {
                context.Result = new HttpErrorResult(context.Request,
                httpResponseException.Response.StatusCode, httpResponseException);
                return;
            }
            context.Result = new HttpErrorResult(context.Request, HttpStatusCode.InternalServerError,
            exception);
        }
    }
}
