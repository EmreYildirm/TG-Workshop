using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using TG_Workshop_Web.Helper;
using TG_Workshop_Web.Models;

namespace TG_Workshop_Web.Services
{
    /// <summary>
    /// Service that controls the processes of our products
    /// </summary>
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> GetProductListWithQuery(ProductQueryViewModel query);
    }
    /// <summary>
    /// It is the http service that controls the operations of our products. Microservice is obliged to send http request.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public ProductService(HttpClient client)
        {
            //Address and headers are specified for a request to a specific microservice.
            _client = client ?? throw new ArgumentNullException(nameof(client));

            client.BaseAddress = new Uri("https://localhost:44300/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            _client = client;
        }

        /// <summary>
        /// The method that sends the http request we run to fetch the products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var response = await _client.GetAsync("/api/Product/GetProducts");

            return await response.ReadContentAs<List<Product>>();

        }


        /// <summary>
        /// The method that sends the http request we run to fetch products by category
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductListWithQuery(ProductQueryViewModel query)
        {
            var dataAsString = JsonSerializer.Serialize(query);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = _client.PostAsync("api/Product/GetProductListWithQuery", content).Result;

            return await response.ReadContentAs<List<Product>>();
        }
    }
}
