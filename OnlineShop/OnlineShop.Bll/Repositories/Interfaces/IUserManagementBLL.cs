using System.Collections.Generic;
using OnlineShop.Common;

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
        bool SearForEmail(string email);
        bool SearchForUsername(string username);

        //Update
        void UpdateUser(Users entity);

        //Delete
        void RemoveUser(Users user);
        void RemoveUserById(int id);
    }
}
