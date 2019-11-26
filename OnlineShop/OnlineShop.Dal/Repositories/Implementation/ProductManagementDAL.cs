using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class ProductManagementDAL : BaseDAL, IProductManagementDAL
    {
        public ProductManagementDAL(OnlineShopAlphaContext dbContext) 
            : base(dbContext) { }

        public IEnumerable<Products> AllProducts => DbContext.Products.AsEnumerable();

        public void AddProduct(Products product)
        {
            DbContext.Products.Add(product);
            DbContext.SaveChanges();
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

        public void UpdateProduct(Products entity)
        {
            DbContext.Products.Update(entity);
            DbContext.SaveChanges();
        }
    }
}
