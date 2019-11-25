using System.Collections.Generic;
using OnlineShop.Common;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    public interface IUserManagementDAL
    {
        //Create
        void AddUser(Users user);

        //Read
        IEnumerable<Users> AllUsers { get; }
        Users GetUserById(int id);
        Users GetUserByUsername(string username);
        bool SearForEmail(string email);
        bool SearchForUsername(string username);

        //Update
        void UpdateUser(Users entity);
        Users GetUserByEmail(string email);


        //Delete
        void RemoveUser(Users user);
        void RemoveUserById(int id);
    }
}
