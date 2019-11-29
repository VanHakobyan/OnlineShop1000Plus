using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common;
using System.Collections.Generic;

namespace OnlineShop.Api.Controllers
{
    public class ItemsController : CustomBaseController
    {
        private readonly IItemsService _itemsService;
        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult CreateItem([FromBody] Items itemModel)
        {
            var item = _itemsService.AddItem(itemModel.Color, itemModel.Size, itemModel.Quantity, itemModel.Image);
            return Ok(item);
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult RemoveItem([FromQuery(Name = "ItemId")] int id)
        {
            _itemsService.DeleteItem(id);
            return Ok();
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult EditItem([FromBody] Items itemModel)
        {
            var newItem = _itemsService.AddItem(itemModel.Color, itemModel.Size, itemModel.Quantity, itemModel.Image);
            return Ok(newItem);
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Items([FromQuery(Name ="count")] int count, [FromQuery(Name = "page")] int page)
        {
            IEnumerable<Items> items = _itemsService.GetAllItemsByPage(count, page);
            return Ok(items);
        }
    }
}