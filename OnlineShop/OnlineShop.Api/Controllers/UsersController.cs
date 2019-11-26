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

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _usersService.Authenticate(model.Email, model.Password);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authorize([FromBody]AuthorizeModel model)
        {
            var user = _usersService.Authorize(model.Email, model.Username, model.FirstName, model.LastName, model.Password, model.ConfirmPassword);
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