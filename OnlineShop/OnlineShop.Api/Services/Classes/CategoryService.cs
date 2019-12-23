using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Api.Services.Classes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryManagementBLL _categoryManagementBLL;
        public CategoryService(ICategoryManagementBLL categoryManagementBLL)
        {
            _categoryManagementBLL = categoryManagementBLL;
        }

        public IEnumerable<Categories> GetAllCategoriesByPage(int count, int page)
        {
            return _categoryManagementBLL.GetAllCategoriesByPage(count, page);
        }

        public Categories GetCategory(int id)
        {
            return _categoryManagementBLL.GetCategory(id);
        }

        public Categories AddCategory(string name)
        {
            var category = new Categories { Name = name };
            return _categoryManagementBLL.AddCategory(category);
        }

        public void RemoveCategory(int id)
        {
            _categoryManagementBLL.RemoveCategory(id);
        }

        public Categories UpdateCategory(Categories oldCategory, Categories newCategory)
        {
            return _categoryManagementBLL.UpdateCategory(oldCategory, newCategory);
        }
    }
}
