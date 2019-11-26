using OnlineShop.Common;
using System.Collections.Generic;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    public interface IProductManagementDAL
    {
        //Create
        void AddProduct(Products product);

        //Read
        IEnumerable<Products> AllProducts { get; }
        Products GetProductById(int id);
        Products  GetProductByName(string name);
        IEnumerable<Products> GetProductsByPage(int count, int page);

        //Update
        void UpdateProduct(Products entity);

        //Delete
        void RemoveProduct(params Products[] product);
        void RemoveProductById(int id);
    }
}
