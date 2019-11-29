using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Common;

namespace OnlineShop.Api.Services.Interfaces
{
    public interface IUsersService
    {
        Users Authenticate(string email, string password);
        Users Authorize(string username, string email, string firstName, string lastName, string password, string confirmPassword);

        IEnumerable<Users> GetAllUsersByPage(int count, int page);
        Users GetUserByUsername(string username);

        Addresses AddAddress(string country, string state, string city, string street, string zip, string phone);
    }
}
