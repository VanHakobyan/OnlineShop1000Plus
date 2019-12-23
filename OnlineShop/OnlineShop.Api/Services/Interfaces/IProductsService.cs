using System.Collections.Generic;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface IProductsService
    {
        Products AddProduct(string name, string description, int? categoryId, decimal? price);
        IEnumerable<Products> GetProductsByPage(int count, int page);
        IEnumerable<Products> GetProductsByPageInCategory(int count, int page, int categoryId);
        void DeleteProduct(int id);
        Products UpdateProduct(Products oldProduct, Products newProduct);
        Products GetById(int id);
    }
}
