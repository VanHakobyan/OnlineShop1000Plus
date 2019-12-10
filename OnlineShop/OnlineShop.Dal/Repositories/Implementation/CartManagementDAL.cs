using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class CartManagementDAL : BaseDAL, ICartManagementDAL
    {
        public CartManagementDAL(OnlineShopAlphaContext dbContext)
            : base(dbContext) { }

        public IEnumerable<Cart> ViewCart(int userId)
        {
            return DbContext.Cart.Where(x => x.UserId == userId).AsEnumerable();
        }

        public IEnumerable<Cart> AddItemToCart(int userId, int itemId)
        {
            var newCartItem = new Cart { UserId = userId, ItemId = itemId };
            DbContext.Cart.Add(newCartItem);
            var item = DbContext.Items.Find(itemId);
            item.Quantity--;
            DbContext.SaveChanges();
            return DbContext.Cart.Where(x => x.UserId == userId).AsEnumerable();
        }

        public IEnumerable<Cart> RemoveItemFromCart(int userId, int itemId)
        {
            var oldCartItem = DbContext.Cart.FirstOrDefault(x => x.ItemId == itemId & x.UserId == userId);
            DbContext.Cart.Remove(oldCartItem);
            var item = DbContext.Items.Find(itemId);
            item.Quantity++;
            DbContext.SaveChanges();
            return DbContext.Cart.Where(x => x.UserId == userId).AsEnumerable();
        }

        public bool IsInCart(int userId, int itemId)
        {
            if (DbContext.Cart.Any(x => x.UserId == userId & x.ItemId == itemId))
            {
                return true;
            }
            else return false;
        }

        public Orders PlaceOrder(int cartId)
        {
            var cart = DbContext.Cart.Find(cartId);
            var order = new Orders { UserId = cart.UserId, Date = DateTime.Now};
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();
            IEnumerable<Cart> userCart = DbContext.Cart.Where(x => x.UserId == cart.UserId).AsEnumerable();
            foreach (var item in userCart)
            {
                DbContext.ItemsOrders.Add(new ItemsOrders { OrderId = order.Id, ItemId = (int)item.ItemId });
            }
            DbContext.SaveChanges();
            return order;
        }

        public void CancelOrder(int orderID)
        {
            var order = DbContext.Orders.Find(orderID);
            DbContext.Orders.Remove(order);
            DbContext.SaveChanges();
        }

        public IEnumerable<Orders> OrderHistory(int userId)
        {
            return DbContext.Orders.Where(x => x.UserId == userId).AsEnumerable();
        }

        public Orders GetOrderById(int id)
        {
            return DbContext.Orders.Find(id);
        }
    }
}
