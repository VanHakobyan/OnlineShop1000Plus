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
    }
}
