using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace NaGreen.WebApi.Infrastructure.ActionResults
{
    public class HttpErrorResult : IHttpActionResult
    {
        private readonly Exception _exception;
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpStatusCode _statusCode;

        public HttpErrorResult(HttpRequestMessage requestMessage, HttpStatusCode statusCode,
        Exception exception)
        {
            _requestMessage = requestMessage;
            _statusCode = statusCode;
            _exception = exception;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestMessage.CreateErrorResponse(_statusCode, Create(_exception)));
        }

        public HttpError Create(Exception exception)
        {
            var properties = exception.GetType().GetProperties(BindingFlags.Instance
                                                             | BindingFlags.Public
                                                             | BindingFlags.DeclaredOnly);
            var error = new HttpError();
            foreach (var propertyInfo in properties)
            {
                error.Add(propertyInfo.Name, propertyInfo.GetValue(exception, null));
            }
            return error;
        }

    }
}
