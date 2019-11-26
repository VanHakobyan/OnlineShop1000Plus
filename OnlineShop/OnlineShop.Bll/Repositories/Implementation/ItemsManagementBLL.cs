using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Bll.Repositories.Implementation
{
    class ItemsManagementBLL : IItemsManagementBLL
    {
        OnlineShopDAL _onlineShopDAL;
        IItemsManagementDAL _itemsManagementDAL;

        public ItemsManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL();
            _itemsManagementDAL = _onlineShopDAL.ItemsManagementDAL;
        }

        public IEnumerable<Items> AllItems => _itemsManagementDAL.AllItems;

        public void AddItem(Items item)
        {
            _itemsManagementDAL.AddItem(item);
        }

        public Items GetItemById(int id)
        {
            return _itemsManagementDAL.GetItemById(id);
        }

        public void RemoveItemById(int id)
        {
            _itemsManagementDAL.RemoveItemById(id);
        }

        public void UpdateItem(Items entity)
        {
            _itemsManagementDAL.UpdateItem(entity);
        }

        public void RemoveItem(params Items[] items)
        {
            _itemsManagementDAL.RemoveItems(items);
        }
    }
}
