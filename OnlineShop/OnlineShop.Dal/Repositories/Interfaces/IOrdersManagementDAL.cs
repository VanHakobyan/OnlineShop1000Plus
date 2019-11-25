using OnlineShop.Common;
using System.Collections.Generic;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    interface IOrdersManagementDAL
    {
        //Create
        void AddOrder(Orders order);

        //Read
        IEnumerable<Orders> AllOrders { get; }
        Orders GetOrderById(int id);
        
        //Update
        void UpdateOrder(Orders entity);

        //Delete
        void RemoveOrders(params Orders[] orders);
        void RemoveOrderById(int id);
    }
}
