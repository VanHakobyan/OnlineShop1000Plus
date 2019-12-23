using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Common.DbModels;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class ProductManagementDAL : BaseDAL, IProductManagementDAL
    {
        public ProductManagementDAL(OnlineShopAlphaContext dbContext) 
            : base(dbContext) { }

        public IEnumerable<Products> AllProducts => DbContext.Products.AsEnumerable();

        public Products AddProduct(Products product)
        {
            DbContext.Products.Add(product);
            DbContext.SaveChanges();
            return product;
        }

        public Products GetProductById(int id)
        {
            return DbContext.Products.Find(id);
        }

        public Products GetProductByName(string name)
        {
            return DbContext.Products.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Products> GetProductsByPage(int count, int page)
        {
            return AllProducts.Skip((page - 1) * count).Take(count);
        }

        public IEnumerable<Products> GetProductsByPageInCategory(int count, int page, int categoryId)
        {
            return AllProducts.Where(x => x.CategoryId == categoryId).Skip((page - 1) * count).Take(count);
        }

        public void RemoveProduct(params Products[] product)
        {
            DbContext.Products.RemoveRange(product as IEnumerable<Products>);
            DbContext.SaveChanges();
        }

        public void RemoveProductById(int id)
        {
            DbContext.Products.Remove(GetProductById(id));
            DbContext.SaveChanges();
        }

        public Products UpdateProduct(Products oldProduct, Products newProduct)
        {
            oldProduct.Name = newProduct.Name;
            oldProduct.Description = newProduct.Description;
            oldProduct.CategoryId = newProduct.CategoryId;
            oldProduct.Price = newProduct.Price;
            DbContext.SaveChanges();
            return newProduct;
        }
    }
}
