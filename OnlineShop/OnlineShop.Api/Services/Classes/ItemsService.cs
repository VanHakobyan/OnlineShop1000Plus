using System.Collections.Generic;
using OnlineShop.Common;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Api.Services.Interfaces;

namespace OnlineShop.Api.Services.Classes
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsManagementBLL _itemsManagementBLL;
        public ItemsService(IItemsManagementBLL itemsManagementBLL)
        {
            _itemsManagementBLL = itemsManagementBLL;
        }
        public Items AddItem(int? color, int? size, int? quantity, string image)
        {
            var item = new Items { Color = color, Size = size, Quantity = quantity, Image = image };

            _itemsManagementBLL.AddItem(item);

            return item;
        }

        public void DeleteItem(int id)
        {
            _itemsManagementBLL.RemoveItemById(id);
        }

        public Items UpdateItem(int? color, int? size, int? quantity, string image)
        {
            var newItem = new Items { Color = color, Size = size, Quantity = quantity, Image = image };
            _itemsManagementBLL.UpdateItem(newItem);

            return newItem;
        }

        public IEnumerable<Items> GetAllItemsByPage(int count, int page)
        {
            return _itemsManagementBLL.GetAllItemsByPage(count, page);
        }

        public bool SearchById(int id)
        {
            return _itemsManagementBLL.SearchById(id);
        }

        public Items GetById(int id)
        {
            return _itemsManagementBLL.GetItemById(id);
        }
    }
}
