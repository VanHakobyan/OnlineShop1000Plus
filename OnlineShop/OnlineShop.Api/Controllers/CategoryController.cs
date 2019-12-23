using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common.DbModels;
using Serilog;

namespace OnlineShop.Api.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// gets all categories
        /// </summary>
        /// <param name="count">count of categories per page</param>
        /// <param name="page">page number</param>
        /// <returns>all existing categories</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Categories([FromQuery(Name = "count")] int count, [FromQuery(Name = "page")] int page)
        {
            try
            {
                IEnumerable<Categories> categories = _categoryService.GetAllCategoriesByPage(count, page);
                if (categories == null)
                {
                    return NotFound("No categories found!");
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CategoryController.Categories() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// gets a category by Id
        /// </summary>
        /// <param name="id">id of the category</param>
        /// <returns>the category, if exists</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Category([FromQuery(Name = "id")] int id)
        {
            try
            {
                var category = _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound("Category not found!");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CategoryController.Category() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// adds a category
        /// </summary>
        /// <param name="categoryModel">category model for add</param>
        /// <remarks>
        /// sample request (this request adds new address)\
        /// POST  /category/addcategory\
        /// {\
        ///     "Name" : "sampleName",\
        ///}
        /// </remarks>>
        /// <returns>added category</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult AddCategory([FromBody] Categories categoryModel)
        {
            try
            {
                var category = _categoryService.AddCategory(categoryModel.Name);
                if (category == null)
                {
                    return BadRequest("Category not specified");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CategoryController.AddCategory() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// updates existing category
        /// </summary>
        /// <param name="newCategoryModel">new info to update</param>
        /// <param name="oldId">id of the category to be updated</param>
        /// <remarks>
        /// sample request (this request adds new address)\
        /// PUT  /category/updatecategory\
        /// {\
        ///     "Name" : "sampleName",\
        ///}
        /// </remarks>>
        /// <returns>updated category</returns>
        [HttpPut]
        [ProducesDefaultResponseType]
        public IActionResult UpdateCategory([FromBody] Categories newCategoryModel, [FromQuery(Name = "oldCategoryId")] int oldId)
        {
            try
            {
                var oldCategory = _categoryService.GetCategory(oldId);
                var newCategory = _categoryService.UpdateCategory(oldCategory, newCategoryModel);
                if (oldCategory == null)
                {
                    return NotFound("Category not found!");
                }
                else if (newCategory == null)
                {
                    return BadRequest("Update info missing!");
                }
                return Ok(newCategory);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CategoryController.UpdateCategory() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// removes a category by Id
        /// </summary>
        /// <param name="id">id of the category to be removed</param>
        [HttpDelete]
        [ProducesDefaultResponseType]
        public IActionResult RemoveCategory([FromQuery(Name = "id")] int id)
        {
            try
            {
                var category = _categoryService.GetCategory(id);
                if (category != null)
                {
                    _categoryService.RemoveCategory(id);
                    return Ok();
                }
                return NotFound("Category not found!");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CategoryController.RemoveCategory() method!");
                return NotFound();
            }
        }
    }
}