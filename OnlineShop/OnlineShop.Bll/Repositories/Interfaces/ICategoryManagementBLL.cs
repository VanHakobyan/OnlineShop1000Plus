using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Interfaces
{
    public interface ICategoryManagementBLL
    {
        IEnumerable<Categories> AllCategories { get; }
        IEnumerable<Categories> GetAllCategoriesByPage(int count, int page);
        Categories GetCategory(int id);
        Categories AddCategory(Categories category);
        void RemoveCategory(int id);
        Categories UpdateCategory(Categories oldCategory, Categories newCategory);
    }
}
