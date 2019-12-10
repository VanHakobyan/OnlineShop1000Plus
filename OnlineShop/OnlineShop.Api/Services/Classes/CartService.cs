using System.Collections.Generic;
using OnlineShop.Common;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Api.Services.Interfaces;

namespace OnlineShop.Api.Services.Classes
{
    public class CartService : ICartService
    {
        private readonly ICartManagementBLL _cartManagementBLL;
        public CartService(ICartManagementBLL cartManagementBLL)
        {
            _cartManagementBLL = cartManagementBLL;
        }

        public IEnumerable<Cart> ViewCart(int userId)
        {
            return _cartManagementBLL.ViewCart(userId);
        }

        public IEnumerable<Cart> AddItemToCart(int userId, int itemId)
        {
            return _cartManagementBLL.AddItemToCart(userId, itemId);
        }

        public IEnumerable<Cart> RemoveItemFromCart(int userId, int itemId)
        {
            return _cartManagementBLL.RemoveItemFromCart(userId, itemId);
        }

        public bool IsInCart(int userId, int itemId)
        {
            return _cartManagementBLL.IsInCart(userId, itemId);
        }

        public Orders PlaceOrder(int cartId)
        {
            return _cartManagementBLL.PlaceOrder(cartId);
        }

        public void CancelOrder(int orderId)
        {
            _cartManagementBLL.CancelOrder(orderId);
        }

        public IEnumerable<Orders> OrderHistory(int userId)
        {
            return _cartManagementBLL.OrderHistory(userId);
        }

        public Orders GetOrderById(int orderId)
        {
            return _cartManagementBLL.GetOrderById(orderId);
        }
    }
}
