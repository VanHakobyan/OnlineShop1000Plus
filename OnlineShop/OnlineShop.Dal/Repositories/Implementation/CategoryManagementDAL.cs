using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Dal.Repositories.Interfaces;
using OnlineShop.Common;
using System.Linq;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class CategoryManagementDAL : BaseDAL, ICategoryManagementDAL
    {
        public CategoryManagementDAL(OnlineShopAlphaContext dbContext)
            : base(dbContext) { }
        
        public IEnumerable<Categories> AllCategories => DbContext.Categories.AsEnumerable();

        public IEnumerable<Categories> GetAllCategoriesByPage(int count, int page)
        {
            return AllCategories.Skip((page - 1) * count).Take(count);
        }

        public Categories GetCategory(int id)
        {
            return DbContext.Categories.Find(id);
        }

        public Categories AddCategory(Categories category)
        {
            DbContext.Categories.Add(category);
            DbContext.SaveChanges();
            return category;
        }

        public void RemoveCategory(int id)
        {
            DbContext.Categories.Remove(GetCategory(id));
            DbContext.SaveChanges();
        }

        public Categories UpdateCategory(Categories oldCategory, Categories newCategory)
        {
            oldCategory.Name = newCategory.Name;
            DbContext.SaveChanges();
            return newCategory;
        }
    }
}
