using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Bll.Repositories.Implementation;
using OnlineShop.Bll.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Common;

namespace OnlineShop.Api.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IProductManagementBLL _productsBLL;
        public ProductController(IProductManagementBLL productsBLL)
        {
            _productsBLL = productsBLL;
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
            var products = _productsBLL.GetProductsByPage(count, page);
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
            _productsBLL.AddProduct(product);
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
            _productsBLL.RemoveProductById(id);
            return Ok($"Remove product: {_productsBLL.AllProducts.FirstOrDefault(x => x.Id == id).Name}");
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
            _productsBLL.UpdateProduct(product);
            return Ok($"Update product: {product.Name}");
        }
    }
}