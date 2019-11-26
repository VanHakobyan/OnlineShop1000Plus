using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;
using OnlineShop.Dal.Repositories.Interfaces;
using System.Collections.Generic;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class OrdersManagementBLL : IOrdersManagementBLL
    {
        OnlineShopDAL _onlineShopDAL;
        IOrdersManagementDAL _orderManagementDAL;
        public OrdersManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL();
            _orderManagementDAL = _onlineShopDAL.OrdersManagementDAL;
        }

        public IEnumerable<Orders> AllOrders => _orderManagementDAL.AllOrders;

        public void AddOrder(Orders order)
        {
            _orderManagementDAL.AddOrder(order);
        }

        public Orders GetOrderById(int id)
        {
            return _orderManagementDAL.GetOrderById(id);
        }

        public void RemoveOrders(params Orders[] orders)
        {
            _orderManagementDAL.RemoveOrders(orders);
        }

        public void RemoveOrderById(int id)
        {
            _orderManagementDAL.RemoveOrderById(id);
        }

        public void UpdateOrder(Orders entity)
        {
            _orderManagementDAL.UpdateOrder(entity);
        }
    }
}
