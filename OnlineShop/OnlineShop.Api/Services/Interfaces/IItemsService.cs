using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Common;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface IItemsService
    {
        Items AddItem(int? color, int? size, int? quantity, string image);
        IEnumerable<Items> GetAllItemsByPage(int counte, int page);
        void DeleteItem(int id);
        Items UpdateItem(int? color, int? size, int? quantity, string image);
    }
}
