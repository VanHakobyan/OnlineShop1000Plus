using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class OrdersManagementDAL : BaseDAL, IOrdersManagementDAL
    {
        public OrdersManagementDAL(OnlineShopAlphaContext dbContext)
            : base(dbContext) { }

        public IEnumerable<Orders> AllOrders => DbContext.Orders.AsEnumerable();

        public void AddOrder(Orders order)
        {
            DbContext.Orders.Add(order);
            DbContext.SaveChanges();
        }

        public Orders GetOrderById(int id)
        {
            return DbContext.Orders.Find(id);
        }

        public void RemoveOrders(params Orders[] orders)
        {
            DbContext.Orders.RemoveRange(orders);
            DbContext.SaveChanges();
        }

        public void RemoveOrderById(int id)
        {
            DbContext.Orders.Remove(GetOrderById(id));
            DbContext.SaveChanges();
        }

        public void UpdateOrder(Orders entity)
        {
            DbContext.Orders.Update(entity);
            DbContext.SaveChanges();
        }
    }
}
