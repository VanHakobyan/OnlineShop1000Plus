using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Implementation;

namespace OnlineShop.Bll.Repositories.Implementation
{
    class AddressManagmentBLL : IAddressManagementBLL
    {
        AddressManagementDAL _addressDAL = new AddressManagementDAL();

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
