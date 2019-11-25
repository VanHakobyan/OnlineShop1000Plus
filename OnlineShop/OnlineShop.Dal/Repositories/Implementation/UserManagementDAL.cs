using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class UserManagementDAL : BaseDAL, IUserManagementDAL
    {
        public UserManagementDAL(OnlineShopAlphaContext dbContext) : base(dbContext) { }

        //Create
        public void AddUser(Users user)
        {
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
        }

        //Read
        public IEnumerable<Users> AllUsers => DbContext.Users.AsEnumerable();
        public Users GetUserById(int id)
        {
            return DbContext.Users.Find(id);
        }
        public Users GetUserByUsername(string username)
        {
            return DbContext.Users.FirstOrDefault(x => x.Username == username);
        }
        public Users GetUserByEmail(string email)
        {
            return DbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public bool SearForEmail(string email)
        {
            if (DbContext.Users.Any(x => x.Email == email)) return true;
            return false;
        }

        public bool SearchForUsername(string username)
        {
            if (DbContext.Users.Any(x => x.Username == username)) return true;
            return false;
        }

        //Update
        public void UpdateUser(Users entity)
        {
            DbContext.Users.Update(entity);
            DbContext.SaveChanges();
        }

        //Delete
        public void RemoveUser(Users user)
        {
            DbContext.Users.Remove(user);
            DbContext.SaveChanges();
        }
        public void RemoveUserById(int id)
        {
            DbContext.Users.Remove(GetUserById(id));
            DbContext.SaveChanges();
        }
    }
}
