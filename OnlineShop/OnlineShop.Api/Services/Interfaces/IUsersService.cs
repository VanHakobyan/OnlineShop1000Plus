using System.Collections.Generic;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface IUsersService
    {
        Users Authenticate(string email, string password);
        Users Authorize(string username, string email, string firstName, string lastName, string password, string confirmPassword);

        IEnumerable<Users> GetAllUsersByPage(int count, int page);
        Users GetUserByUsername(string username);
        Users GetUserById(int id);

        Addresses AddAddress(string country, string state, string city, string street, string zip, string phone);
        Addresses GetAddressById(int id);
        void UpdateAddress(Addresses entity);
        void RemoveAddress(int id);
    }
}
