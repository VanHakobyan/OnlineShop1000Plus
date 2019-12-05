using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Common;
using Serilog;

namespace OnlineShop.Api.Controllers
{
    public class TestController : CustomBaseController
    {
      
        public void Logg()
        {
            HttpContext.Response.Redirect("http://localhost:5341/#/events", true);
            //return RedirectToPage("http://localhost:5341/#/events");
        }

        [HttpGet]
        public IActionResult Test()
        {
            int? email = -1;
            try
            {
                OnlineShopAlphaContext context = new OnlineShopAlphaContext(new DbContextOptions<OnlineShopAlphaContext>());
                email = context.Items.FirstOrDefault()?.Color;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, ex.Message);
            }

            return Ok($"Test {DateTime.UtcNow}, Email:{email}");
        }


        [HttpGet]
        public IActionResult Test1()
        {
            return Ok($"Test {DateTime.UtcNow}");
        }

      
    }
}