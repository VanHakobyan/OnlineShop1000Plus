using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common;
using System.Collections.Generic;

namespace OnlineShop.Api.Controllers
{
    [Authorize]
    public class UsersController : CustomBaseController
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        /// <summary>
        /// login a registered user
        /// </summary>
        /// <param name="model">the login form model</param>
        /// <returns>the logged-in user</returns>
        /// <remarks>
        /// sample request (this reques logs in a registered user)\
        /// POST  /users/login\
        /// {\
        ///     "Email" : "sampleEmail",\
        ///     "Password" : "samplePassword"\
        ///}
        /// </remarks>>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]AuthenticateModel model)
        {
            var user = _usersService.Authenticate(model.Email, model.Password);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]AuthorizeModel model)
        {
            var user = _usersService.Authorize(model.Username, model.Email, model.FirstName, model.LastName, model.Password, model.ConfirmPassword);
            return Ok(user);
        }

        [HttpGet]
        public IActionResult Users([FromQuery(Name = "count")]int count, [FromQuery(Name = "page")]int page)
        {
            IEnumerable<Users> users = _usersService.GetAllUsersByPage(count, page);
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Address([FromBody] Addresses addressModel)
        {
            var address = _usersService.AddAddress(addressModel.Country, addressModel.State, addressModel.City, addressModel.Street, addressModel.Zip, addressModel.Phone);
            return Ok(address);
        }
    }
}