using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;
using System.Collections.Generic;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class OrdersManagementBLL : IOrdersManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public OrdersManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL(new DbContextOptions<OnlineShopAlphaContext>());
        }

        public IEnumerable<Orders> AllOrders => _onlineShopDAL.OrdersManagementDAL.AllOrders;

        public void AddOrder(Orders order)
        {
            _onlineShopDAL.OrdersManagementDAL.AddOrder(order);
        }

        public Orders GetOrderById(int id)
        {
            return _onlineShopDAL.OrdersManagementDAL.GetOrderById(id);
        }

        public void RemoveOrders(params Orders[] orders)
        {
            _onlineShopDAL.OrdersManagementDAL.RemoveOrders(orders);
        }

        public void RemoveOrderById(int id)
        {
            _onlineShopDAL.OrdersManagementDAL.RemoveOrderById(id);
        }

        public void UpdateOrder(Orders entity)
        {
            _onlineShopDAL.OrdersManagementDAL.UpdateOrder(entity);
        }
    }
}
