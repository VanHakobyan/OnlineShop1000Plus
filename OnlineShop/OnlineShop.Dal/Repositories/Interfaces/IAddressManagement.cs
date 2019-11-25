using System.Collections.Generic;
using OnlineShop.Common;

namespace OnlineShop.Dal.Repositories
{
    public interface IAddressManagement
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
