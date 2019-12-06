using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class CategoryManagementBLL : ICategoryManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public CategoryManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL(new DbContextOptions<OnlineShopAlphaContext>());
        }

        public IEnumerable<Categories> AllCategories => _onlineShopDAL.categoryManagementDAL.AllCategories;

        public IEnumerable<Categories> GetAllCategoriesByPage(int count, int page)
        {
            return _onlineShopDAL.categoryManagementDAL.GetAllCategoriesByPage(count, page);
        }

        public Categories GetCategory(int id)
        {
            return _onlineShopDAL.categoryManagementDAL.GetCategory(id);
        }

        public Categories AddCategory(Categories category)
        {
            return _onlineShopDAL.categoryManagementDAL.AddCategory(category);
        }

        public void RemoveCategory(int id)
        {
            _onlineShopDAL.categoryManagementDAL.RemoveCategory(id);
        }

        public Categories UpdateCategory(Categories oldCategory, Categories newCategory)
        {
            return _onlineShopDAL.categoryManagementDAL.UpdateCategory(oldCategory, newCategory);
        }
    }
}
