using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Infrastructure.Extensions
{
    public static class HttpRequestMessageExtension
    {
        public static string GetHeader(this HttpRequestMessage request, string name)
        {
            var headers = request.Headers;

            if (headers.Contains(name))
            {
                return headers.GetValues(name).First();
            }

            return null;
        }
    }
}
