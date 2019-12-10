using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common;
using Serilog;

namespace OnlineShop.Api.Controllers
{
    [Authorize]
    public class CartController : CustomBaseController
    {
        private readonly ICartService _cartService;
        private readonly IItemsService _itemsService;
        public CartController(ICartService cartService, IItemsService itemsService)
        {
            _cartService = cartService;
            _itemsService = itemsService;
        }

        /// <summary>
        /// shows the cart of the user
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <returns>cart of the user</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Cart([FromQuery(Name = "userId")] int userId)
        {
            try
            {
                IEnumerable<Cart> cart = _cartService.ViewCart(userId);
                if (cart == null)
                {
                    return Ok("No items in the cart!");
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CartController.Cart() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// adds an item to the cart
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <param name="itemId">id of the item to be added to the cart</param>
        /// <returns>resulted cart</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult AddToCart([FromQuery(Name = "userId")] int userId, [FromQuery(Name = "itemId")] int itemId)
        {
            try
            {
                IEnumerable<Cart> cart = _cartService.AddItemToCart(userId, itemId);
                var item = _itemsService.GetById(itemId);
                if (item != null & item.Quantity == 0)
                {
                    return NotFound("Item expired!");
                }
                else if (cart == null)
                {
                    return BadRequest("Could not add to cart!");
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CartController.AddToCart() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// removes an item from the cart
        /// </summary>
        /// <param name="userId">id of the user></param>
        /// <param name="itemId">id of the item to be removed</param>
        /// <returns>resulted cart</returns>
        [HttpDelete]
        [ProducesDefaultResponseType]
        public IActionResult Remove([FromQuery(Name = "userId")] int userId, [FromQuery(Name = "itemId")] int itemId)
        {
            try
            {
                if (_cartService.IsInCart(userId, itemId))
                {
                    IEnumerable<Cart> cart = _cartService.RemoveItemFromCart(userId, itemId);
                    return Ok(cart);
                }
                else return NotFound("Item not in the cart!");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CartController.Remove() method!");
                return NotFound();
            }
        }
    }
}