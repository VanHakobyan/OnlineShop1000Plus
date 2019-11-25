﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Common;

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
    }
}