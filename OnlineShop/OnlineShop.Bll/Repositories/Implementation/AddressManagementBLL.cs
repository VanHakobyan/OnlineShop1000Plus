using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class AddressManagementBLL : IAddressManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public AddressManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL();
        }
        public IEnumerable<Addresses> AllAddresses => _onlineShopDAL.AddressManagementDAL.AllAddresses;

        public void AddAddress(Addresses newAddress)
        {
            _onlineShopDAL.AddressManagementDAL.AddAddress(newAddress);
        }

        public Addresses GetAddressById(int id)
        {
            return _onlineShopDAL.AddressManagementDAL.GetAddressById(id);
        }

        public Addresses GetAddressByUser(Users user)
        {
            return _onlineShopDAL.AddressManagementDAL.GetAddressByUser(user);
        }

        public void RemoveAddress(Addresses address)
        {

            _onlineShopDAL.AddressManagementDAL.RemoveAddress(address);
        }

        public void UpdateAddress(Addresses entity)
        {
            _onlineShopDAL.AddressManagementDAL.UpdateAddress(entity);
        }
    }
}
