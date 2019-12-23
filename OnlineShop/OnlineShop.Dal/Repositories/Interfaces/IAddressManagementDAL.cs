using System.Collections.Generic;
using OnlineShop.Common;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    public interface IAddressManagementDAL
    {
        //Create
        void AddAddress(Addresses newAddress);

        //Read
        IEnumerable<Addresses> AllAddresses { get; }
        Addresses GetAddressById(int id);
        Addresses GetAddressByUser(Users user);

        //Update
        void UpdateAddress(Addresses entity);

        //Delete
        void RemoveAddress(Addresses address);
    }
}
