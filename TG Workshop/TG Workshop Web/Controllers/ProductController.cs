using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TG_Workshop_Web.Models;
using TG_Workshop_Web.Services;

namespace TG_Workshop_Web.Controllers
{
    /// <summary>
    /// Controller with page and web methods related to products.
    /// </summary>
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #region Views
        /// <summary>
        /// The method that provides access to the product page.
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductListPage()
        {
            return View("ProductListPage");
        }
        #endregion

        #region API
        /// <summary>
        /// The method that runs when the page is first opened. It brings all the products.
        /// </summary>
        /// <returns></returns>
        [Route("Product/GetProductList")]
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductList()
        {

            var response = await _productService.GetProducts();
            return response;
        }

        /// <summary>
        /// The method that works when the category is selected. It brings our products according to the selected category or categories.
        /// </summary>
        /// <returns></returns>
        [Route("Product/GetProductListWithQuery")]
        [HttpPost]
        public async Task<IEnumerable<Product>> GetProductListWithQuery(ProductQueryViewModel query)
        {
            var response = await _productService.GetProductListWithQuery(query);
            return response;
        }
        #endregion


    }
}
