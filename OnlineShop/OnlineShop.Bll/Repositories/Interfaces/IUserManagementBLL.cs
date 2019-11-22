using System.Collections.Generic;
using OnlineShop.Models;

namespace OnlineShop.Bll.Repositories
{
    public interface IUserManagementBLL
    {
        //Create
        void AddUser(Users user);

        //Read
        IEnumerable<Users> AllUsers { get; }
        Users GetUserById(int id);
        Users GetUserByUsername(string username);
        Users GetUserByEmail(string email);

        //Update
        void UpdateUser(Users entity);

        //Delete
        void RemoveUser(Users user);
        void RemoveUserById(int id);
    }
}
