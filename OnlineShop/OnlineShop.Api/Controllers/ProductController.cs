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
        private readonly IProductManagementBLL _productsBLL = new ProductManagementBLL();

        [HttpGet]
        public IActionResult GetProducts([FromQuery(Name = "count")] int count, [FromQuery(Name = "page")] int page)
        {
            var products = _productsBLL.GetProductsByPage(count, page);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Products product)
        {
            _productsBLL.AddProduct(product);
            return Ok();
        }

        [HttpPost]
        public IActionResult DeleteProduct([FromQuery(Name = "ProductId")] int id)
        {
            _productsBLL.RemoveProductById(id);
            return Ok($"Remove product: {_productsBLL.AllProducts.FirstOrDefault(x => x.Id == id).Name}");
        }

        [HttpPost]
        public IActionResult EditProduct([FromBody] Products product)
        {
            _productsBLL.UpdateProduct(product);
            return Ok($"Update product: {product.Name}");
        }
    }
}