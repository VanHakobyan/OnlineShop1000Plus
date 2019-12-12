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

        /// <summary>
        /// shows order history of the user
        /// </summary>
        /// <param name="userid">id of the user</param>
        /// <returns>order history, if available</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult OrderHistory([FromQuery(Name = "userId")] int userid)
        {
            try
            {
                var ordHistory = _cartService.OrderHistory(userid);
                if (ordHistory == null)
                {
                    return NotFound("There are no orders available!");
                }
                return Ok(ordHistory);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CartController.OrderHistory() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// places a new order from an existing user cart
        /// </summary>
        /// <param name="cartId">id of the cart to be ordered</param>
        /// <returns>order, if successful</returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult PlaceOrder([FromQuery] int cartId)
        {
            try
            {
                var order = _cartService.PlaceOrder(cartId);
                if (order == null)
                {
                    return NotFound("Order not specified!");
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CartController.PlaceOrder() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// removes a placed order within 1 hour after being ordered
        /// </summary>
        /// <param name="orderId">id of the order to be removed</param>
        [HttpDelete]
        [ProducesDefaultResponseType]
        public IActionResult CancelOrder([FromQuery(Name = "orderId")] int orderId)
        {
            try
            {
                var order = _cartService.GetOrderById(orderId);
                if (order != null)
                {
                    _cartService.CancelOrder(orderId);
                    return Ok();
                }
                return NotFound("Order does not exist!");
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.CartController.CancelOrder() method!");
                return NotFound();
            }
        }
    }
}