using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    class ItemsManagementDAL : BaseDAL, IItemsManagementDAL
    {
        public ItemsManagementDAL(OnlineShopAlphaContext dbContext)
            : base(dbContext) { }

        public IEnumerable<Items> AllItems => DbContext.Items.AsEnumerable();
        public IEnumerable<Items> GetAllItemsByPage(int count, int page)
        {
            return AllItems.Skip((page - 1) * count).Take(count);
        }

        public IEnumerable<Items> GetAllItemsOfProductByPage(int count, int page, int productId)
        {
            return AllItems.Where(x => x.ProductId == productId).Skip((page - 1) * count).Take(count);
        }

        public Items AddItem(Items item)
        {
            DbContext.Items.Add(item);
            DbContext.SaveChanges();
            return item;
        }

        public Items GetItemById(int id)
        {
            return DbContext.Items.Find(id);
        }

        public void RemoveItems(params Items[] items)
        {
            DbContext.Items.RemoveRange(items as IEnumerable<Items>);
            DbContext.SaveChanges();
        }

        public void RemoveItemById(int id)
        {
            DbContext.Items.Remove(GetItemById(id));
            DbContext.SaveChanges();
        }

        public Items UpdateItem(Items oldItem, Items newItem)
        {
            oldItem.ProductId = newItem.ProductId;
            oldItem.Color = newItem.Color;
            oldItem.Size = newItem.Size;
            oldItem.Quantity = newItem.Quantity;
            oldItem.Image = newItem.Image;
            DbContext.SaveChanges();
            return newItem;
        }

        public bool SearchById(int id)
        {
            if(DbContext.Items.Any(x => x.Id == id)) return true;
            return false;
        }
    }
}
