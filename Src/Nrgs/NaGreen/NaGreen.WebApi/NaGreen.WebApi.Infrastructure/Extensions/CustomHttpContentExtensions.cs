using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Infrastructure.Extensions
{
    public static class CustomHttpContentExtensions
    {
        /// <summary>
        /// Reads content of message and throw if there are any exceptions.
        /// </summary>
        public async static Task<T> SafeReadAsAsync<T>(this HttpContent httpContent)
        {
            T result = default(T);
            result = await httpContent.ReadAsAsync<T>().ContinueWith<T>((Task<T> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;
                return x.Result;
            });
            return result;
        }
    }
}
