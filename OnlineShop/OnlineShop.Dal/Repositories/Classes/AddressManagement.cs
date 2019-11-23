using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models;

namespace OnlineShop.Dal.Repositories
{
    public class AddressManagement : IAddressManagement
    {
        OnlineShopAlphaContext context = new OnlineShopAlphaContext();

        public IEnumerable<Addresses> AllAddresses => context.Addresses.AsEnumerable();

        public void AddAddress(Addresses newAddress)
        {
            context.Addresses.Add(newAddress);
            context.SaveChanges();
        }

        public Addresses GetAddressById(int id)
        {
            return context.Addresses.Find(id);
        }

        public Addresses GetAddressByUser(Users user)
        {
            return context.Addresses.FirstOrDefault(x => x.Id == user.AddressId);
        }

        public void RemoveAddress(Addresses address)
        {
            context.Addresses.Remove(address);
            context.SaveChanges();
        }

        public void UpdateAddress(Addresses entity)
        {
            context.Addresses.Update(entity);
            context.SaveChanges();
        }
    }
}
