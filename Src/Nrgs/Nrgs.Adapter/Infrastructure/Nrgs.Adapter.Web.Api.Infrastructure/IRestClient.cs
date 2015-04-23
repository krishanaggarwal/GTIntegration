using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nrgs.Adapter.Web.Api.Infrastructure
{
    public interface IRestClient<T> where T : class
    {
        /// <summary>
        /// Gets or sets BaseAddress.
        /// </summary>
        string BaseAddress { get; set; }

        /// <summary>
        /// For getting item from a web api uaing GET
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api get method, e.g. "products/1" to get a product with an id of 1</param>
        /// <returns>The item requested</returns>
        Task<T> GetItemRequest(string apiUrl);

        /// <summary>
        /// For getting multiple (or all) items from a web api using GET
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api get method, e.g. "products?page=1" to get page 1 of the products</param>
        /// <returns>The items requested</returns>
        Task<T[]> GetMultipleItemsRequest(string apiUrl);

        /// <summary>
        /// For creating a new item over a web api using POST
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api post method, e.g. "products" to add products</param>
        /// <param name="postObject">The object to be created</param>
        /// <returns>The item created</returns>
        Task<T> PostRequest(string apiUrl, T postObject);
        
        /// <summary>
        /// For updating an existing item over a web api using PUT
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api put method, e.g. "products/3" to update product with id of 3</param>
        /// <param name="putObject">The object to be edited</param>
        Task PutRequest(string apiUrl, T putObject);

        /// <summary>
        /// For deleting an existing item over a web api using DELETE
        /// </summary>
        /// <param name="apiUrl">Added to the base address to make the full url of the 
        /// api delete method, e.g. "products/3" to delete product with id of 3</param>
        Task DeleteRequest(string apiUrl);
    }
}
