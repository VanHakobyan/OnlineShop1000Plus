using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common.DbModels;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class ItemsManagementBLL : IItemsManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public ItemsManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL(new DbContextOptions<OnlineShopAlphaContext>());
        }

        public IEnumerable<Items> AllItems => _onlineShopDAL.ItemsManagementDAL.AllItems;
        public IEnumerable<Items> GetAllItemsByPage(int count, int page)
        {
           return _onlineShopDAL.ItemsManagementDAL.GetAllItemsByPage(count, page);
        }

        public IEnumerable<Items> GetAllItemsOfProductByPage(int count, int page, int productId)
        {
            return _onlineShopDAL.ItemsManagementDAL.GetAllItemsOfProductByPage(count, page, productId);
        }

        public Items AddItem(Items item)
        {
            return _onlineShopDAL.ItemsManagementDAL.AddItem(item);
        }

        public Items GetItemById(int id)
        {
            return _onlineShopDAL.ItemsManagementDAL.GetItemById(id);
        }

        public void RemoveItemById(int id)
        {
            _onlineShopDAL.ItemsManagementDAL.RemoveItemById(id);
        }

        public Items UpdateItem(Items oldItem, Items newItem)
        {
           return _onlineShopDAL.ItemsManagementDAL.UpdateItem(oldItem, newItem);
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
