using System;
using OnlineShop.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Api.Helpers;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using OnlineShop.Common;
using OnlineShop.Bll.Repositories.Interfaces;

namespace OnlineShop.Api.Services.Classes
{
    public class UsersService : IUsersService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserManagementBLL _userManagementBLL;
        public UsersService(IOptions<JwtSettings> jwtSettings, IUserManagementBLL userManagementBLL)
        {
            _jwtSettings = jwtSettings.Value;
            _userManagementBLL = userManagementBLL;
        }

        public Users Authenticate(string email, string password)
        {
            // check if email or password are not empty
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                throw new AppExceptions("Email or password empty");

            // check if user already registered
            if (_userManagementBLL.GetUserByEmail(email) is null)
                throw new AppExceptions("Email not found");

            // get user by email
            Users user = _userManagementBLL.GetUserByEmail(email);

            // authentication successful, so jwt token is to generate
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public Users Authorize(string username, string email, string firstName, string lastName, string password, string confirmPassword)
        {
            // password validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppExceptions("Password is required");

            if (confirmPassword != password)
                throw new AppExceptions("Password not confirmed");

            // email validation
            if (string.IsNullOrWhiteSpace(email) )
                throw new AppExceptions("Email is required");

            if (!_userManagementBLL.SearForEmail(email))
                throw new AppExceptions($"Email \"{email}\" is already taken");

            if (!EmailValidation.IsValidEmail(email))
                throw new AppExceptions("Invalid email");

            // username validation
            if (string.IsNullOrWhiteSpace(username))
                throw new AppExceptions("Username is required");

            if (_userManagementBLL.SearchForUsername(username))
                throw new AppExceptions($"Username \"{username}\" is already taken");

            // first name & last name validation
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new AppExceptions("Invalid first or last name");

            // if all checks passed, create user
            var user = new Users { FirstName = firstName, LastName = lastName, Email = email, Username = username, Password = password, RegistrationDate = DateTime.Now.Date };

            // authorization successful, so jwt token is to generate
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // add user to db
            _userManagementBLL.AddUser(user);

            return user;
        }

        // get all users with paging
        public IEnumerable<Users> GetAllUsersByPage(int count, int page)
        {
            return _userManagementBLL.GetAllUsersByPage(count, page);
        }
    }
}
