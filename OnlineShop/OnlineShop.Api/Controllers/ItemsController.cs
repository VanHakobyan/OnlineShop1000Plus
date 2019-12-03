using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common;

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
        /// creates an item of a product
        /// </summary>
        /// <param name="itemModel">item specific properties</param>
        /// <returns>new item</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult CreateItem([FromBody] Items itemModel)
        {
            var item = _itemsService.AddItem(itemModel.Color, itemModel.Size, itemModel.Quantity, itemModel.Image);
            if (item == null)
            {
                return BadRequest("Item not specified!");
            }
            else if (item.Quantity == 0)
            {
                return NoContent();
            }
            return Ok(item);
        }

        /// <summary>
        /// deletes existing item
        /// </summary>
        /// <param name="id">item id</param>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult RemoveItem([FromQuery(Name = "ItemId")] int id)
        {
            if (_itemsService.SearchById(id))
            {
                _itemsService.DeleteItem(id);
                return Ok();
            }
            return NotFound("Item not found"!);
        }

        /// <summary>
        /// updates item info
        /// </summary>
        /// <param name="itemModel">new item properties</param>
        /// <returns>updated item</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult EditItem([FromBody] Items itemModel)
        {
            var newItem = _itemsService.AddItem(itemModel.Color, itemModel.Size, itemModel.Quantity, itemModel.Image);
            if (newItem == null)
            {
                return BadRequest("New characteristics not specified!");
            }
            return Ok(newItem);
        }

        /// <summary>
        /// gets all available items of a product
        /// </summary>
        /// <param name="count">count of items per page</param>
        /// <param name="page">page number</param>
        /// <returns>all available items</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Items([FromQuery(Name ="count")] int count, [FromQuery(Name = "page")] int page)
        {
            IEnumerable<Items> items = _itemsService.GetAllItemsByPage(count, page);
            if (items == null)
            {
                return NotFound("No items of the product found!");
            }
            return Ok(items);
        }
    }
}