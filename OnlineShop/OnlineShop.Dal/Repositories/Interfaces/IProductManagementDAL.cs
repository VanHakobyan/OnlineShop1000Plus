using OnlineShop.Common;
using System.Collections.Generic;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    interface IProductManagementDAL
    {
        //Create
        void AddProduct(Products product);

        //Read
        IEnumerable<Products> AllProducts { get; }
        Products GetProductById(int id);
        Products  GetProductByName(string name);

        //Update
        void UpdateProduct(Products entity);

        //Delete
        void RemoveProduct(params Products[] product);
        void RemoveProductById(int id);
    }
}
