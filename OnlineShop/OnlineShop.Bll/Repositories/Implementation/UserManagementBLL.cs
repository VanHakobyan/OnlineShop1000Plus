using System.Collections.Generic;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class UserManagementBLL : IUserManagementBLL
    {
        OnlineShopDAL _onlineShopDAL;
        IUserManagementDAL _userManagementDAL;

        public UserManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL();
            _userManagementDAL = _onlineShopDAL.UserManagementDAL;
        }

        public IEnumerable<Users> AllUsers => _userManagementDAL.AllUsers;
        public IEnumerable<Users> GetAllUsersByPage(int count, int page)
        {
            return _userManagementDAL.GetAllUsersByPage(count, page);
        }

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

        public bool SearForEmail(string email)
        {
            return _userManagementDAL.SearForEmail(email);
        }
        public bool SearchForUsername(string username)
        {
            return _userManagementDAL.SearchForUsername(username);
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
