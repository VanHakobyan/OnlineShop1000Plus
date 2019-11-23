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
        public Users GetUserByEmail(string email)
        {
            return context.Users.FirstOrDefault(x => x.Email == email);
        }

        //Update
        public void UpdateUser(Users entity)
        {
            context.Users.Update(entity);
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
