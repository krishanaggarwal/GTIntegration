using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Nrgs.Adapter.Web.Api.Infrastructure.Extensions;
using Nrgs.Adapter.Common.Constants;
using Nrgs.Adapter.Common.Exceptions;

namespace Nrgs.Adapter.Web.Api.Infrastructure
{
    public class RestClient<T> : IRestClient<T> where T : class
    {
        private string _baseAddress;
        private IHttpContextService _httpContextService;
        //public RestClient(string baseAddress)
        //{
        //    _baseAddress = baseAddress;
        //}

        public RestClient(IHttpContextService httpContextService)
        {
            _httpContextService = httpContextService;
        }

        public string BaseAddress
        {
            get
            {
                return _baseAddress;
            }
            set
            {
                _baseAddress = value;
            }
        }

        /// <summary>
        /// Used to setup the base address, that we want json, and authentication headers for the request
        /// </summary>
        /// <param name="client">The HttpClient we are configuring</param>
        /// <param name="methodName">GET, POST, PUT or DELETE.</param>
        /// <param name="apiUrl">The end bit of the url we use to call the web api method</param>
        /// <param name="content">For posts and puts the object we are including</param>
        private void SetupClient(HttpClient client, string methodName, string apiUrl, T content = null)
        {

            client.BaseAddress = new Uri(_baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ExtractAndAddHeader(client,Constants.HeaderNames.DateUtc);
            ExtractAndAddHeader(client, Constants.HeaderNames.X_Forwarded_For_UserAgent);
            ExtractAndAddHeader(client, Constants.HeaderNames.X_Forwarded_For_UserIp);

            client.DefaultRequestHeaders.Authorization = _httpContextService.CurrentRequest.GetAuthorizationHeader();

        }

        private void ExtractAndAddHeader(HttpClient client, string name)
        {
            var headerValue = _httpContextService.CurrentRequest.GetHeader(name);
            if (headerValue != null)
            {
                client.DefaultRequestHeaders.Add(name, headerValue);
            }
        }

        /// <summary>
        /// For getting a single item from a web api uaing GET
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api get method, e.g. "products/1" to get a product with an id of 1</param>
        /// <returns>The item requested</returns>
        public async Task<T> GetItemRequest(string apiUrl)
        {
            T result = default(T);

            using (var client = new HttpClient())
            {
                SetupClient(client, "GET", apiUrl);

                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    var exception = new NrgsAdapterException();
                    exception.Error.ErrorDescription = response.ReasonPhrase;
                    exception.Error.HttpStatus = response.StatusCode;
                    throw exception;
                }
                //response.EnsureSuccessStatusCode();


                result = await response.Content.SafeReadAsAsync<T>();
            }

            return result;
        }

        /// <summary>
        /// For getting multiple (or all) items from a web api using GET
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api get method, e.g. "products?page=1" to get page 1 of the products</param>
        /// <returns>The items requested</returns>
        public async Task<T[]> GetMultipleItemsRequest(string apiUrl)
        {
            T[] result = null;

            using (var client = new HttpClient())
            {
                SetupClient(client, "GET", apiUrl);

                var response = await client.GetAsync(apiUrl).ConfigureAwait(false);
                
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new NrgsAdapterException();
                    exception.Error.ErrorDescription = response.ReasonPhrase;
                    exception.Error.HttpStatus = response.StatusCode;
                    throw exception;
                }
                //response.EnsureSuccessStatusCode();

                result = await response.Content.SafeReadAsAsync<T[]>();
            }

            return result;
        }


        /// <summary>
        /// For creating a new item over a web api using POST
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api post method, e.g. "products" to add products</param>
        /// <param name="postObject">The object to be created</param>
        /// <returns>The item created</returns>
        public async Task<T> PostRequest(string apiUrl, T postObject)
        {
            T result = null;

            using (var client = new HttpClient())
            {
                SetupClient(client, "POST", apiUrl, postObject);

                var response = await client.PostAsync(apiUrl, postObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new NrgsAdapterException();
                    exception.Error.ErrorDescription = response.ReasonPhrase;
                    exception.Error.HttpStatus = response.StatusCode;
                    throw exception;
                }
                //response.EnsureSuccessStatusCode();

                result = await response.Content.SafeReadAsAsync<T>();
            }

            return result;
        }

        /// <summary>
        /// For updating an existing item over a web api using PUT
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api put method, e.g. "products/3" to update product with id of 3</param>
        /// <param name="putObject">The object to be edited</param>
        public async Task PutRequest(string apiUrl, T putObject)
        {
            using (var client = new HttpClient())
            {
                SetupClient(client, "PUT", apiUrl, putObject);

                var response = await client.PutAsync(apiUrl, putObject, new JsonMediaTypeFormatter()).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new NrgsAdapterException();
                    exception.Error.ErrorDescription = response.ReasonPhrase;
                    exception.Error.HttpStatus = response.StatusCode;
                    throw exception;
                }
                //response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// For deleting an existing item over a web api using DELETE
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api delete method, e.g. "products/3" to delete product with id of 3</param>
        public async Task DeleteRequest(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                SetupClient(client, "DELETE", apiUrl);

                var response = await client.DeleteAsync(apiUrl).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    var exception = new NrgsAdapterException();
                    exception.Error.ErrorDescription = response.ReasonPhrase;
                    exception.Error.HttpStatus = response.StatusCode;
                    throw exception;
                }
                //response.EnsureSuccessStatusCode();
            }
        }
    }
}
