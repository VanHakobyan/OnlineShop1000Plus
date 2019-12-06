using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common;
using Serilog;

namespace OnlineShop.Api.Controllers
{
    public class ItemsController : CustomBaseController
    {
        private readonly IItemsService _itemsService;
        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        /// <summary>
        /// gets all items
        /// </summary>
        /// <param name="count">count of items per page</param>
        /// <param name="page">page number</param>
        /// <returns>all available items</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Items([FromQuery(Name = "count")] int count, [FromQuery(Name = "page")] int page)
        {
            try
            {
                IEnumerable<Items> items = _itemsService.GetAllItemsByPage(count, page);
                if (items == null)
                {
                    return NotFound("No item found!");
                }
                return Ok(items);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ItemsController.Items() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// gets all items of the specific product
        /// </summary>
        /// <param name="count">count of items per page</param>
        /// <param name="page">page number</param>
        /// <param name="prodId">id of the product</param>
        /// <returns>all available items of the product</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult ItemsOfProduct([FromQuery(Name = "count")] int count, [FromQuery(Name = "page")] int page, [FromQuery(Name = "productId")] int prodId)
        {
            try
            {
                IEnumerable<Items> itemsOfProduct = _itemsService.GetAllItemsOfProductByPage(count, page, prodId);
                if (itemsOfProduct == null)
                {
                    return NotFound("No item of the product found!");
                }
                return Ok(itemsOfProduct);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ItemsController.ItemsOfProduct() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// gets an item by Id
        /// </summary>
        /// <param name="id">id of the item</param>
        /// <returns>item, if exists</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Item([FromQuery(Name = "id")] int id)
        {
            try
            {
                var item = _itemsService.GetById(id);
                if (item == null)
                {
                    return NotFound("Item not found!");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ItemsController.Item() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// adds a new item
        /// </summary>
        /// <param name="itemModel">item info model</param>
        /// <remarks>
        /// POST  /items/createitem\
        /// {\
        ///     "ProductId" : "sampleProductId"\
        ///     "Color" : "sampleColor",\
        ///     "Size" : "sampleSize",\
        ///     "Quantity" : "sampleQuantity",\
        ///     "Image" : "sampleImage",\
        ///}
        /// </remarks>
        /// <returns>created item</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult CreateItem([FromBody] Items itemModel)
        {
            try
            {
                var item = _itemsService.AddItem(itemModel.ProductId, itemModel.Color, itemModel.Size, itemModel.Quantity, itemModel.Image);
                if (item == null)
                {
                    return BadRequest("Item not specified!");
                }
                else if (item.Quantity == 0)
                {
                    return NotFound("Item expired!");
                }
                return Ok(item);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ItemsController.CreateItem() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// updates item info
        /// </summary>
        /// <param name="itemModel">new item properties</param>
        /// <param name="itemId">id of the item to be edited</param>
        /// <returns>updated item</returns>
        /// <remarks>
        /// sample request (this request adds new address)\
        /// PUT  /items/edititem\
        /// {\
        ///     "ProductId" : "sampleProductId"\    
        ///     "Color" : "sampleColor",\
        ///     "Size" : "sampleSize",\
        ///     "Quantity" : "sampleQuantity",\
        ///     "Image" : "sampleImage",\
        ///}
        /// </remarks>
        /// <returns>updated item</returns>
        [HttpPut]
        [ProducesDefaultResponseType]
        public IActionResult EditItem([FromBody] Items itemModel, [FromQuery(Name = "itemId")] int itemId)
        {
            try
            {
                var oldItem = _itemsService.GetById(itemId);
                var newItem = _itemsService.UpdateItem(oldItem, itemModel);
                if (oldItem == null)
                {
                    return BadRequest("Item not found!");
                }
                else if (itemModel == null)
                {
                    return BadRequest("Update info missing!");
                }
                return Ok(newItem);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ItemsController.EditItem() method!");
                return NotFound();
            }
        }


        /// <summary>
        /// deletes existing item
        /// </summary>
        /// <param name="id">id of the item to be deleted</param>
        [HttpDelete]
        [ProducesDefaultResponseType]
        public IActionResult RemoveItem([FromQuery(Name = "ItemId")] int id)
        {
            try
            {
                if (_itemsService.SearchById(id))
                {
                    _itemsService.DeleteItem(id);
                    return Ok();
                }
                return NotFound("Item not found"!);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.ItemsController.RemoveItem() method!");
                return NotFound();
            }
        }
    }
}