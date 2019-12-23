using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Bll.Repositories.Interfaces;
using System.Collections.Generic;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Api.Services.Classes
{
    public class ProductsService : IProductsService
    {
        private readonly IProductManagementBLL _productsManagementBLL;
        public ProductsService(IProductManagementBLL productManagementBLL)
        {
            _productsManagementBLL = productManagementBLL;
        }
        public Products AddProduct(string name, string description, int? categoryId, decimal? price)
        {
            return _productsManagementBLL.AddProduct(new Products { Name = name, Description = description, CategoryId = categoryId, Price = price});
        }

        public void DeleteProduct(int id)
        {
            _productsManagementBLL.RemoveProductById(id);
        }

        public IEnumerable<Products> GetProductsByPage(int count, int page)
        {
            return _productsManagementBLL.GetProductsByPage(count, page);
        }

        public IEnumerable<Products> GetProductsByPageInCategory(int count, int page, int categoryId)
        {
            return _productsManagementBLL.GetProductsByPageInCategory(count, page, categoryId);
        }

        public Products UpdateProduct(Products oldProduct, Products newProduct)
        {
            return _productsManagementBLL.UpdateProduct(oldProduct, newProduct);
        }

        public Products GetById(int id)
        {
            return _productsManagementBLL.GetProductById(id);
        }
    }
}
