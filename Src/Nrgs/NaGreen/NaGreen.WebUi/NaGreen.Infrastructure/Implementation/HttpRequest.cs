using NaGreen.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.Infrastructure.Implementation
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequestMessage Request { get; set; }

        public HttpClient Client { get; set; }

        public HttpResponseMessage Response { get; set; }

        public HttpRequest(HttpRequestMessage request)
        {
            this.Client = new HttpClient();
            this.Request = request;
        }

        public HttpRequest(string uri)
        {
            this.Client = new HttpClient();
            this.Request = new HttpRequestMessage();
            this.Request.RequestUri = new Uri(uri);
        }

        public async Task<string> Send()
        {
            Response = await Client.SendAsync(Request);
            string responseString = await Response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(responseString))
            {
                return Response.ReasonPhrase;
            }

            return responseString;
        }
    }

}
