using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class ItemsManagementBLL : IItemsManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public ItemsManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL();
        }

        public IEnumerable<Items> AllItems => _onlineShopDAL.ItemsManagementDAL.AllItems;
        public IEnumerable<Items> GetAllItemsByPage(int count, int page)
        {
           return _onlineShopDAL.ItemsManagementDAL.GetAllItemsByPage(count, page);
        }

        public void AddItem(Items item)
        {
            _onlineShopDAL.ItemsManagementDAL.AddItem(item);
        }

        public Items GetItemById(int id)
        {
            return _onlineShopDAL.ItemsManagementDAL.GetItemById(id);
        }

        public void RemoveItemById(int id)
        {
            _onlineShopDAL.ItemsManagementDAL.RemoveItemById(id);
        }

        public void UpdateItem(Items entity)
        {
            _onlineShopDAL.ItemsManagementDAL.UpdateItem(entity);
        }

        public void RemoveItem(params Items[] items)
        {
            _onlineShopDAL.ItemsManagementDAL.RemoveItems(items);
        }

        public bool SearchById(int id)
        {
            return _onlineShopDAL.ItemsManagementDAL.SearchById(id);
        }
    }
}
