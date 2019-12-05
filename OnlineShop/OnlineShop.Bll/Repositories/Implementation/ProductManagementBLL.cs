using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
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

        public void AddProduct(Products product)
        {
            _onlineShopDAL.ProductManagementDAL.AddProduct(product);
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

        public void RemoveProduct(params Products[] products)
        {
            _onlineShopDAL.ProductManagementDAL.RemoveProduct(products);
        }

        public void RemoveProductById(int id)
        {
            _onlineShopDAL.ProductManagementDAL.RemoveProductById(id);
        }

        public void UpdateProduct(Products entity)
        {
            _onlineShopDAL.ProductManagementDAL.UpdateProduct(entity);
        }
    }
}
