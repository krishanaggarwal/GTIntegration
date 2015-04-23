using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nrgs.Adapter.Web.Api.Infrastructure.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetHeader(this HttpRequest request, string name)
        {
            var headers = request.Headers;

            if (headers.AllKeys.Contains(name))
            {
                return headers.GetValues(name).First();
            }

            return null;
        }

        public static AuthenticationHeaderValue GetAuthorizationHeader(this HttpRequest request)
        {
            var values = request.Headers["Authorization"].Split(' ');
            return new AuthenticationHeaderValue(values[0], string.Format("{0} {1}",values[1], values[2]));
        }
    }
}
