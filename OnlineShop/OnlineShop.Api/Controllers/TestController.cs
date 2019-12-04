using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using Serilog;

namespace OnlineShop.Api.Controllers
{
    public class TestController : CustomBaseController
    {
        private readonly IUserManagementBLL _userManagementBLL;
        public TestController(IUserManagementBLL userManagementBLL)
        {
            _userManagementBLL = userManagementBLL;
        }
        
        public void Logg()
        {
            HttpContext.Response.Redirect("http://localhost:5341/#/events",true);
            //return RedirectToPage("http://localhost:5341/#/events");
        }

        [HttpGet]
        public IActionResult Test()
        {
            try
            {
                int a = 0;
                int b = 5 / a;
            }
            catch(Exception ex)
            {
                Log.Logger.Error(ex, ex.Message);
            }
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