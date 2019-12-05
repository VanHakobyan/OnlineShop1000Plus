using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;
using OnlineShop.Api.Services.Interfaces;
using Serilog;

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
            try
            {
                var products = _productsService.GetProductsByPage(count, page);
                if (products == null)
                {
                    return NotFound("No products available!");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.Products() method!");
                return NotFound();
            }
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
            try
            {
                _productsService.AddProduct(product.Name, product.Description, product.CategoryId, product.Price);
                if (product == null)
                {
                    return BadRequest("Product not specified!");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.AddProduct() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// deletes existing product
        /// </summary>
        /// <param name="id">product id</param>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult DeleteProduct([FromQuery(Name = "ProductId")] int id)
        {
            try
            {
                _productsService.DeleteProduct(id);
                return Ok(); //TODO: FIX possible null reference issue --> --> --> FIXED
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.DeleteProduct() method!");
                return NotFound();
            }
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
            try
            {
                _productsService.UpdateProduct(product);
                if (product == null)
                {
                    return BadRequest("New characteristics not specified!");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.EditProduct() method!");
                return NotFound();
            }
        }
    }
}