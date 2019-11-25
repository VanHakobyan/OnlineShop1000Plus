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

        public void AddItem(Items item)
        {
            DbContext.Items.Add(item);
            DbContext.SaveChanges();
        }

        public Items GetItemById(int id)
        {
            return DbContext.Items.Find(id);
        }

        public void RemoveItem(params Items[] items)
        {
            DbContext.Items.RemoveRange(items as IEnumerable<Items>);
            DbContext.SaveChanges();
        }

        public void RemoveItemById(int id)
        {
            DbContext.Items.Remove(GetItemById(id));
            DbContext.SaveChanges();
        }

        public void UpdateItem(Items entity)
        {
            DbContext.Items.Update(entity);
            DbContext.SaveChanges();
        }
    }
}
