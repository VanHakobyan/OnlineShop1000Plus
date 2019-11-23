using System.Collections.Generic;
using OnlineShop.Models;
using OnlineShop.Dal.Repositories;

namespace OnlineShop.Bll.Repositories
{
    class AddressManagmentBLL : IAddressManagementBLL
    {
        AddressManagement _addressDAL = new AddressManagement();

        public IEnumerable<Addresses> AllAddresses => _addressDAL.AllAddresses;

        public void AddAddress(Addresses newAddress)
        {
            _addressDAL.AddAddress(newAddress);
        }

        public Addresses GetAddressById(int id)
        {
            return _addressDAL.GetAddressById(id);
        }

        public Addresses GetAddressByUser(Users user)
        {
            return _addressDAL.GetAddressByUser(user);
        }

        public void RemoveAddress(Addresses address)
        {
            _addressDAL.RemoveAddress(address);
        }

        public void UpdateAddress(Addresses entity)
        {
            _addressDAL.UpdateAddress(entity);
        }
    }
}
