using System.Collections.Generic;
using OnlineShop.Models;

namespace OnlineShop.Dal.Repositories
{
    public interface IUserManagement
    {
        //Create
        void AddUser(Users user);

        //Read
        IEnumerable<Users> AllUsers { get; }
        Users GetUserById(int id);
        Users GetUserByUsername(string username);

        //Update
        void UpdateUser(Users entity);

        //Delete
        void RemoveUser(Users user);
        void RemoveUserById(int id);
    }
}
