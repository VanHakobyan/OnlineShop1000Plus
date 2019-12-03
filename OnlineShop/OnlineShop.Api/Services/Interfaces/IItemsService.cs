using System.Collections.Generic;
using OnlineShop.Common;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface IItemsService
    {
        Items AddItem(int? color, int? size, int? quantity, string image);
        IEnumerable<Items> GetAllItemsByPage(int count, int page);
        void DeleteItem(int id);
        Items UpdateItem(int? color, int? size, int? quantity, string image);
        bool SearchById(int id);
    }
}
