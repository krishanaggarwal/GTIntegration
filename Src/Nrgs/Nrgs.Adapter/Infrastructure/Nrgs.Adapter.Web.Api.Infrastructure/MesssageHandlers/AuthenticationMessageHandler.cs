using Nrgs.Adapter.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Nrgs.Adapter.Web.Api.Infrastructure.MesssageHandlers
{
    public class AuthenticationMessageHandler : DelegatingHandler
    {
        public const char AuthorizationHeaderSeparator = ':';

        public  AuthenticationMessageHandler()
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //_log.Debug("Already authenticated; passing on to next handler...");
                return await base.SendAsync(request, cancellationToken);
            }

            //if (request.RequestUri.Scheme != Uri.UriSchemeHttps)
            //{
            //    return CreateUnauthorizedResponse();
            //}

            if (CanHandleAuthentication(request))
            {
                //_log.Debug("Not a basic auth request; passing on to next handler...");
                return await base.SendAsync(request, cancellationToken);
            }
 
            return CreateUnauthorizedResponse();
        }

        public bool CanHandleAuthentication(HttpRequestMessage request)
        {
            return true;
            return (request.Headers != null
            && request.Headers.Authorization != null
            && (request.Headers.Authorization.Scheme.ToLowerInvariant() ==
            Constants.SchemeTypes.V1 || request.Headers.Authorization.Scheme.ToLowerInvariant() ==
            Constants.SchemeTypes.P1));
        }

        public HttpResponseMessage CreateUnauthorizedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.WwwAuthenticate.Add(
            new AuthenticationHeaderValue(Constants.SchemeTypes.V1));
            return response;
        }
    }
}
