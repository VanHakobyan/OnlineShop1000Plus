using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using OnlineShop.Dal;

namespace OnlineShop.Bll.Repositories.Implementation
{
    public class UserManagementBLL : IUserManagementBLL
    {
        private readonly OnlineShopDAL _onlineShopDAL;
        public UserManagementBLL()
        {
            _onlineShopDAL = new OnlineShopDAL(new DbContextOptions<OnlineShopAlphaContext>());
        }

        public IEnumerable<Users> AllUsers => _onlineShopDAL.UserManagementDAL.AllUsers;
        public IEnumerable<Users> GetAllUsersByPage(int count, int page)
        {
            return _onlineShopDAL.UserManagementDAL.GetAllUsersByPage(count, page);
        }

        public void AddUser(Users user)
        {
            _onlineShopDAL.UserManagementDAL.AddUser(user);
        }

        public Users GetUserByEmail(string email)
        {
            return _onlineShopDAL.UserManagementDAL.GetUserByEmail(email);
        }

        public Users GetUserById(int id)
        {
            return _onlineShopDAL.UserManagementDAL.GetUserById(id);
        }

        public Users GetUserByUsername(string username)
        {
            return _onlineShopDAL.UserManagementDAL.GetUserByUsername(username);
        }

        public bool SearchForEmail(string email)
        {
            return _onlineShopDAL.UserManagementDAL.SearchForEmail(email);
        }
        public bool SearchForUsername(string username)
        {
            return _onlineShopDAL.UserManagementDAL.SearchForUsername(username);
        }

        public void RemoveUser(Users user)
        {
            _onlineShopDAL.UserManagementDAL.RemoveUser(user);
        }

        public void RemoveUserById(int id)
        {
            _onlineShopDAL.UserManagementDAL.RemoveUserById(id);
        }

        public void UpdateUser(Users entity)
        {
            _onlineShopDAL.UserManagementDAL.UpdateUser(entity);
        }
    }
}
