using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Bll.Repositories.Implementation
{
    class AddressManagementBLL : IAddressManagementBLL
    {
        OnlineShopDAL _onlineShopDAL;
        IAddressManagementDAL _addressManagementDAL;

        public AddressManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL();
            _addressManagementDAL = _onlineShopDAL.AddressManagementDAL;
        }
        public IEnumerable<Addresses> AllAddresses => _addressManagementDAL.AllAddresses;

        public void AddAddress(Addresses newAddress)
        {
            _addressManagementDAL.AddAddress(newAddress);
        }

        public Addresses GetAddressById(int id)
        {
            return _addressManagementDAL.GetAddressById(id);
        }

        public Addresses GetAddressByUser(Users user)
        {
            return _addressManagementDAL.GetAddressByUser(user);
        }

        public void RemoveAddress(Addresses address)
        {

            _addressManagementDAL.RemoveAddress(address);
        }

        public void UpdateAddress(Addresses entity)
        {
            _addressManagementDAL.UpdateAddress(entity);
        }
    }
}
