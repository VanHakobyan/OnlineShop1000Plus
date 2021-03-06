﻿using System.Collections.Generic;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Categories> GetAllCategoriesByPage(int count, int page);
        Categories GetCategory(int id);
        Categories AddCategory(string name);
        void RemoveCategory(int id);
        Categories UpdateCategory(Categories oldCategory, Categories newCategory);
    }
}
