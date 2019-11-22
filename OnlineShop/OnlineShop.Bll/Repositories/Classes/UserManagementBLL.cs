using System.Collections.Generic;
using OnlineShop.Dal.Repositories;
using OnlineShop.Models;

namespace OnlineShop.Bll.Repositories
{
    public class UserManagementBLL : IUserManagementBLL
    {
        IUserManagement _userManagementDAL = new UserManagement();

        public IEnumerable<Users> AllUsers => _userManagementDAL.AllUsers;

        public void AddUser(Users user)
        {
            _userManagementDAL.AddUser(user);
        }

        public Users GetUserByEmail(string email)
        {
            return _userManagementDAL.GetUserByEmail(email);
        }

        public Users GetUserById(int id)
        {
            return _userManagementDAL.GetUserById(id);
        }

        public Users GetUserByUsername(string username)
        {
            return _userManagementDAL.GetUserByUsername(username);
        }

        public void RemoveUser(Users user)
        {
            _userManagementDAL.RemoveUser(user);
        }

        public void RemoveUserById(int id)
        {
            _userManagementDAL.RemoveUserById(id);
        }

        public void UpdateUser(Users entity)
        {
            _userManagementDAL.UpdateUser(entity);
        }
    }
}
