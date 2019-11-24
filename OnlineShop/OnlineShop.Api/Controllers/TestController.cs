using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Bll.Repositories;
using OnlineShop.Dal;
using OnlineShop.Models;

namespace OnlineShop.Api.Controllers
{
    public class TestController : CustomBaseController
    {
        private readonly IUserManagementBLL _userManagementBLL;
        public TestController(IUserManagementBLL userManagementBLL)
        {
            _userManagementBLL = userManagementBLL;
        }
        public IActionResult Test()
        {
            OnlineShopAlphaContext context = new OnlineShopAlphaContext();
            return Ok($"Test {DateTime.UtcNow}");
        }

        [HttpGet]
        public IActionResult UserByEmail([FromBody]string email)
        {
            _userManagementBLL.GetUserByEmail(email);
            return Ok();

        }
    }
}