using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.Infrastructure.Base
{
    public interface IHttpRequest
    {
        HttpRequestMessage Request { get; set; }

        HttpClient Client { get; set; }

        HttpResponseMessage Response { get; set; }

        Task<string> Send();
    }
}
