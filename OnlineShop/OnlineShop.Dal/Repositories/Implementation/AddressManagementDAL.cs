﻿using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class AddressManagementDAL : IAddressManagementDAL
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
            if (address.Users.Count == 0)
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }
        }

        public void UpdateAddress(Addresses entity)
        {
            context.Addresses.Update(entity);
            context.SaveChanges();
        }
    }
}