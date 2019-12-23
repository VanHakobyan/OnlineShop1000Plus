using System.Collections.Generic;
using OnlineShop.Common.DbModels;

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
