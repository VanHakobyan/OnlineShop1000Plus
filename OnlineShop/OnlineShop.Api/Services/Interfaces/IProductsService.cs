using OnlineShop.Common;
using System.Collections.Generic;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface IProductsService
    {
        void AddProduct(Products product);
        IEnumerable<Products> GetProductsByPage(int count, int page);
        void DeleteProduct(int id);
        void UpdateProduct(Products entity);
    }
}
