using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common.DbModels;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class ProductManagementBLL : IProductManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public ProductManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL(new DbContextOptions<OnlineShopAlphaContext>());
        }

        public IEnumerable<Products> AllProducts => _onlineShopDAL.ProductManagementDAL.AllProducts;

        public Products AddProduct(Products product)
        {
            return _onlineShopDAL.ProductManagementDAL.AddProduct(product);
        }

        public Products GetProductById(int id)
        {
            return _onlineShopDAL.ProductManagementDAL.GetProductById(id);
        }

        public Products GetProductByName(string name)
        {
            return _onlineShopDAL.ProductManagementDAL.GetProductByName(name);
        }

        public IEnumerable<Products> GetProductsByPage(int count, int page)
        {
            return _onlineShopDAL.ProductManagementDAL.GetProductsByPage(count, page);
        }

        public IEnumerable<Products> GetProductsByPageInCategory(int count, int page, int categoryId)
        {
            return _onlineShopDAL.ProductManagementDAL.GetProductsByPageInCategory(count, page, categoryId);
        }

        public void RemoveProduct(params Products[] products)
        {
            _onlineShopDAL.ProductManagementDAL.RemoveProduct(products);
        }

        public void RemoveProductById(int id)
        {
            _onlineShopDAL.ProductManagementDAL.RemoveProductById(id);
        }

        public Products UpdateProduct(Products oldProduct, Products newProduct)
        {
            return _onlineShopDAL.ProductManagementDAL.UpdateProduct(oldProduct, newProduct);
        }
    }
}
