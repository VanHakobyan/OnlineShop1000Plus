using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class AddressManagementDAL : BaseDAL, IAddressManagementDAL
    {
        public AddressManagementDAL(OnlineShopAlphaContext context) 
            : base(context) { }

        public IEnumerable<Addresses> AllAddresses => base.DbContext.Addresses.AsEnumerable();

        public void AddAddress(Addresses newAddress)
        {
            DbContext.Addresses.Add(newAddress);
            DbContext.SaveChanges();
        }

        public Addresses GetAddressById(int id)
        {
            return DbContext.Addresses.Find(id);
        }

        public Addresses GetAddressByUser(Users user)
        {
            return DbContext.Addresses.FirstOrDefault(x => x.Id == user.AddressId);
        }

        public void RemoveAddress(Addresses address)
        {
            if (address.Users.Count == 0)
            {
                DbContext.Addresses.Remove(address);
                DbContext.SaveChanges();
            }
        }

        public void UpdateAddress(Addresses entity)
        {
            DbContext.Addresses.Update(entity);
            DbContext.SaveChanges();
        }
    }
}
