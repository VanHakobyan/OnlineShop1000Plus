using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Api.Services.Interfaces;

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
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]string email, string password)
        {
            var user = _usersService.Authenticate(email, password);
            return Ok(user);
        }

        [HttpPost("authorize")]
        public IActionResult Authorize([FromBody]string username, string email, string firstName, string lastName, string password, string confirmPassword)
        {
            var user = _usersService.Authorize(email, password, username, firstName, lastName, confirmPassword);
            return Ok(user);
        }
    }
}