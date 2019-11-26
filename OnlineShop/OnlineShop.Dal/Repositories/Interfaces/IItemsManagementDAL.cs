using System.Collections.Generic;
using OnlineShop.Common;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    public interface IItemsManagementDAL
    {
        //Create
        void AddItem(Items item);

        //Read
        IEnumerable<Items> AllItems { get; }
        Items GetItemById(int id);

        //Update
        void UpdateItem(Items entity);

        //Delete
        void RemoveItem(params Items[] items);
        void RemoveItemById(int id);
    }
}
