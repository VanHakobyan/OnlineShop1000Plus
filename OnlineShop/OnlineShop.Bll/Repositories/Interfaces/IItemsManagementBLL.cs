using System.Collections.Generic;
using OnlineShop.Common;

namespace OnlineShop.Bll.Repositories.Interfaces
{
    public interface IItemsManagementBLL
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
        void RemoveItem(params Items[] items);
        void RemoveItemById(int id);
    }
}
