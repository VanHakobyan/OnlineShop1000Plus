using System.Collections.Generic;
using OnlineShop.Common;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    public interface IItemsManagementDAL
    {
        //Create
        Items AddItem(Items item);

        //Read
        IEnumerable<Items> AllItems { get; }
        IEnumerable<Items> GetAllItemsByPage(int count, int page);
        IEnumerable<Items> GetAllItemsOfProductByPage(int count, int page, int productId);
        Items GetItemById(int id);
        bool SearchById(int id);

        //Update
        Items UpdateItem(Items oldItem, Items newItem);

        //Delete
        void RemoveItems(params Items[] items);
        void RemoveItemById(int id);
    }
}
