using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Bll.Repositories.Implementation;

namespace OnlineShop.Api.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        /// <summary>
        /// gets all products in the given category
        /// </summary>
        /// <param name="count">count of products per page</param>
        /// <param name="page">page number</param>
        /// <returns>all available products</returns>
        [HttpGet]
        public IActionResult Products([FromQuery(Name = "count")] int count, [FromQuery(Name = "page")] int page)
        {
            var products = _productsService.GetProductsByPage(count, page);
            return Ok(products);
        }

        /// <summary>
        /// adds new product
        /// </summary>
        /// <param name="product">product specific properties</param>
        /// <returns>new product</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult AddProduct([FromBody] Products product)
        {
            _productsService.AddProduct(product);
            return Ok();
        }

        /// <summary>
        /// deletes existing product
        /// </summary>
        /// <param name="id">product id</param>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult DeleteProduct([FromQuery(Name = "ProductId")] int id)
        {
            _productsService.DeleteProduct(id);
            return Ok(); //TODO: FIX possible null reference issue --> --> --> FIXED
        }

        /// <summary>
        /// updated product info
        /// </summary>
        /// <param name="product">new product properties</param>
        /// <returns>updated product</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult EditProduct([FromBody] Products product)
        {
            _productsService.UpdateProduct(product);
            return Ok();
        }
    }
}