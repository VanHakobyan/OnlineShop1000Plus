using System.Collections.Generic;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Bll.Repositories.Interfaces
{
    public interface IAddressManagementBLL
    {
        void AddAddress(Addresses newAddress);
        IEnumerable<Addresses> AllAddresses { get; }
        Addresses GetAddressById(int id);
        Addresses GetAddressByUser(Users user);
        void UpdateAddress(Addresses entity);
        void RemoveAddress(Addresses address);
    }
}
