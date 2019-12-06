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
        /// gets all products
        /// </summary>
        /// <param name="count">count of products per page</param>
        /// <param name="page">page number</param>
        /// <returns>all available products</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
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
        /// get all products in the selected category
        /// </summary>
        /// <param name="count">count of products per page</param>
        /// <param name="page">page number</param>
        /// <param name="catId">id of the category selected</param>
        /// <returns>all available products in the category</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult ProductsInCategory([FromQuery(Name = "count")] int count, [FromQuery(Name = "page")] int page, [FromQuery(Name = "categoryId")] int catId)
        {
            try
            {
                var productsInCategory = _productsService.GetProductsByPageInCategory(count, page, catId);
                if (productsInCategory == null)
                {
                    return NotFound("No products in the category!");
                }
                return Ok(productsInCategory);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.ProductsInCategory() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// gets a product by id
        /// </summary>
        /// <param name="id">id of the product</param>
        /// <returns>the produxt, if exists</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Product([FromQuery(Name = "id")] int id)
        {
            try
            {
                var product = _productsService.GetById(id);
                if (product == null)
                {
                    return NotFound("Product not found!");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.Product() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// adds new product
        /// </summary>
        /// <param name="product">product specific properties</param>
        /// <remarks>
        /// sample request (this request adds new address)\
        /// POST  /product/addproduct\
        /// {\
        ///     "Name" : "sampleName",\
        ///     "Description" : "sampleDescription",\
        ///     "CategoryId" : "sampleCategoryId",\
        ///     "Price" : "samplePrice",\
        ///}
        /// </remarks>>
        /// <returns>new product</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult AddProduct([FromBody] Products product)
        {
            try
            {
                var addProduct = _productsService.AddProduct(product.Name, product.Description, product.CategoryId, product.Price);
                if (product == null)
                {
                    return BadRequest("Product not specified!");
                }
                return Ok(addProduct);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.AddProduct() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// updated the product
        /// </summary>
        /// <param name="product">update info model</param>
        /// <param name="oldId">idof the product to be updated</param>
        /// <remarks>
        /// PUT  /product/editproduct\
        /// {\
        ///     "Name" : "sampleName",\
        ///     "Description" : "sampleDescription",\
        ///     "CategoryId" : "sampleCategoryId",\
        ///     "Price" : "samplePrice",\
        ///}
        /// </remarks>
        /// <returns>updated product</returns>
        [HttpPut]
        [ProducesDefaultResponseType]
        public IActionResult EditProduct([FromBody] Products product, [FromQuery(Name = "oldId")] int oldId)
        {
            try
            {
                var oldProduct = _productsService.GetById(oldId);
                var newProduct = _productsService.UpdateProduct(oldProduct, product);
                if (oldProduct == null)
                {
                    return BadRequest("Product not found!");
                }
                if (product == null)
                {
                    return BadRequest("New characteristics not specified!");
                }
                return Ok(oldProduct);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.EditProduct() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// deletes existing product by Id
        /// </summary>
        /// <param name="id">product id</param>
        [HttpDelete]
        [ProducesDefaultResponseType]
        public IActionResult DeleteProduct([FromQuery(Name = "productId")] int id)
        {
            try
            {
                var product = _productsService.GetById(id);
                if (product == null)
                {
                    return NotFound("Product not found!");
                }
                _productsService.DeleteProduct(id);
                return Ok(); //TODO: FIX possible null reference issue --> --> --> FIXED
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ProductController.DeleteProduct() method!");
                return NotFound();
            }
        }
    }
}