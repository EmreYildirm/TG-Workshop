using Microsoft.AspNetCore.Mvc;
using ProductService.DataAccesLayer.Repositories;
using ProductService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    /// <summary>
    /// Product  of our microservice
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Endpoint that brings all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProducts();
            return Ok(products);
        }

        /// <summary>
        /// Endpoint that brings products in a certain category
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost(("GetProductListWithQuery"))]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductListWithQuery(QueryModel query)
        {
            var products = await _repository.GetProducts();
            // Brings products by category id
            var queryResult = products.Where(x => query.categories.Contains(x.CategoryId)).ToList();
            return Ok(queryResult);

        }
    }
}
