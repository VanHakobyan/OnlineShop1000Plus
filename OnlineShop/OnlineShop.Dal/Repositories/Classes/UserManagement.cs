using System.Collections.Generic;
using System.Linq;
using OnlineShop.Models;

namespace OnlineShop.Dal.Repositories
{
    public class UserManagement : IUserManagement
    {
        OnlineShopAlphaContext context = new OnlineShopAlphaContext();

        //Create
        public void AddUser(Users user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        //Read
        public IEnumerable<Users> AllUsers => context.Users.AsEnumerable();
        public Users GetUserById(int id)
        {
            return context.Users.Find(id);
        }
        public Users GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }

        //Update
        public void UpdateUser(Users entity)
        {
            var users = GetUserById(entity.Id);

            users.Id = entity.Id;
            users.Username = entity.Username;
            users.FirstName = entity.FirstName;
            users.LastName = entity.LastName;
            users.Email = entity.Email;
            users.Address = entity.Address;
            users.AddressId = entity.AddressId;
            users.Orders = entity.Orders;
            users.Password = entity.Password;
            users.RegistrationDate = entity.RegistrationDate;

            context.SaveChanges();
        }

        //Delete
        public void RemoveUser(Users user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
        public void RemoveUserById(int id)
        {
            context.Users.Remove(GetUserById(id));
            context.SaveChanges();
        }
    }
}
