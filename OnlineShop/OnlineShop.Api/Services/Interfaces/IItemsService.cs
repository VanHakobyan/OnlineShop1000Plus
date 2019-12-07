using System.Collections.Generic;
using OnlineShop.Common;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface IItemsService
    {
        Items AddItem(int? prodId, int? color, int? size, int? quantity, string image);
        IEnumerable<Items> GetAllItemsByPage(int count, int page);
        IEnumerable<Items> GetAllItemsOfProductByPage(int count, int page, int productId);
        void DeleteItem(int id);
        Items UpdateItem(Items oldItem, Items newItem);
        bool SearchById(int id);
        Items GetById(int id);
    }
}
