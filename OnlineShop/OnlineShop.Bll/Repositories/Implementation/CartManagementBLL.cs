using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common.DbModels;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class CartManagementBLL : ICartManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public CartManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL(new DbContextOptions<OnlineShopAlphaContext>());
        }

        public IEnumerable<Cart> ViewCart(int userId)
        {
            return _onlineShopDAL.CartManagementDAL.ViewCart(userId);
        }

        public IEnumerable<Cart> AddItemToCart(int userId, int itemId)
        {
            return _onlineShopDAL.CartManagementDAL.AddItemToCart(userId, itemId);
        }

        public IEnumerable<Cart> RemoveItemFromCart(int userId, int itemId)
        {
            return _onlineShopDAL.CartManagementDAL.RemoveItemFromCart(userId, itemId);
        }

        public bool IsInCart(int userId, int itemId)
        {
            return _onlineShopDAL.CartManagementDAL.IsInCart(userId, itemId);
        }

        public Orders PlaceOrder(int cartId)
        {
            return _onlineShopDAL.CartManagementDAL.PlaceOrder(cartId);
        }

        public void CancelOrder(int orderId)
        {
            var order = _onlineShopDAL.CartManagementDAL.GetOrderById(orderId);
            TimeSpan span = (TimeSpan)(DateTime.Now - order.Date);
            if (span.Hours < 1)
            {
                _onlineShopDAL.CartManagementDAL.CancelOrder(orderId);
            }
        }

        public IEnumerable<Orders> OrderHistory(int userId)
        {
            return _onlineShopDAL.CartManagementDAL.OrderHistory(userId);
        }

        public Orders GetOrderById(int orderId)
        {
            return _onlineShopDAL.CartManagementDAL.GetOrderById(orderId);
        }
    }
}
