using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineShop.Common;
using Serilog;

namespace OnlineShop.Api.Controllers
{
    public class TestController : CustomBaseController
    {
        [HttpGet]
        public void Logg()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            HttpContext.Response.Redirect(configuration.GetValue<string>("SeqServerUrl"), true);
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


            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            return Ok($"Test {DateTime.UtcNow}, Email:{email}, SeqServerUrl: {configuration.GetValue<string>("SeqServerUrl")}");
        }


        [HttpGet]
        public IActionResult Test1()
        {
            return Ok($"Test {DateTime.UtcNow}");
        }


    }
}