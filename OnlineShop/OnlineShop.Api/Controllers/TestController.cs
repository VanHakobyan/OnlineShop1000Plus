using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Api.Controllers
{
    public class TestController : CustomBaseController
    {
        public IActionResult Test()
        {
            return Ok($"Test {DateTime.UtcNow}");
        }
    }
}