using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class ProductManagementBLL : IProductManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        IProductManagementDAL _productManagementDAL;

        public ProductManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL();
            _productManagementDAL = _onlineShopDAL.ProductManagementDAL;
        }

        public IEnumerable<Products> AllProducts => _productManagementDAL.AllProducts;

        public void AddProduct(Products product)
        {
            _productManagementDAL.AddProduct(product);
        }

        public Products GetProductById(int id)
        {
            return _productManagementDAL.GetProductById(id);
        }

        public Products GetProductByName(string name)
        {
            return _productManagementDAL.GetProductByName(name);
        }

        public void RemoveProduct(params Products[] products)
        {
            _productManagementDAL.RemoveProduct(products);
        }

        public void RemoveProductById(int id)
        {
            _productManagementDAL.RemoveProductById(id);
        }

        public void UpdateProduct(Products entity)
        {
            _productManagementDAL.UpdateProduct(entity);
        }
    }
}
