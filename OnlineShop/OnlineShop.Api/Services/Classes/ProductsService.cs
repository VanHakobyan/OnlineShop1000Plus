using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using System.Collections.Generic;

namespace OnlineShop.Api.Services.Classes
{
    public class ProductsService : IProductsService
    {
        private readonly IProductManagementBLL _productsManagementBLL;
        public ProductsService(IProductManagementBLL productManagementBLL)
        {
            _productsManagementBLL = productManagementBLL;
        }
        public void AddProduct(string name, string description, int? categoryId, decimal? price)
        {
            _productsManagementBLL.AddProduct(new Products { Name = name, Description = description, CategoryId = categoryId, Price = price});
        }

        public void DeleteProduct(int id)
        {
            _productsManagementBLL.RemoveProductById(id);
        }

        public IEnumerable<Products> GetProductsByPage(int count, int page)
        {
            return _productsManagementBLL.GetProductsByPage(count, page);
        }

        public void UpdateProduct(Products entity)
        {
            _productsManagementBLL.UpdateProduct(entity);
        }
    }
}
