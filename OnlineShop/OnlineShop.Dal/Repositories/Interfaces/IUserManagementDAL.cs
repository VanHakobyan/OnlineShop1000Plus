using System.Collections.Generic;
using OnlineShop.Common;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    public interface IUserManagementDAL
    {
        //Create
        void AddUser(Users user);

        //Read
        IEnumerable<Users> AllUsers { get; }
        IEnumerable<Users> GetAllUsersByPage(int count, int page);
        Users GetUserById(int id);
        Users GetUserByUsername(string username);
        bool SearchForEmail(string email);
        bool SearchForUsername(string username);

        //Update
        void UpdateUser(Users entity);
        Users GetUserByEmail(string email);


        //Delete
        void RemoveUser(Users user);
        void RemoveUserById(int id);
    }
}
