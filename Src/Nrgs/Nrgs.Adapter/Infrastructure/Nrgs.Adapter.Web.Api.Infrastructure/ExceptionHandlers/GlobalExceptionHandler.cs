using Nrgs.Adapter.Web.Api.Infrastructure.ActionResults;
using Nrgs.Adapter.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Nrgs.Adapter.Common.Exceptions;

namespace Nrgs.Adapter.Web.Api.Infrastructure.ExceptionHandlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception.GetInnerMostException();
            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new HttpErrorResult(context.Request,
                (HttpStatusCode)httpException.GetHttpCode(), httpException);
                return;
            }

            var nrgsException = exception as NrgsAdapterException;
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
