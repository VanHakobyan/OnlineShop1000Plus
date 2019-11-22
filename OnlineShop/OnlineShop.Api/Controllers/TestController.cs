using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Dal;
using OnlineShop.Dal.Repositories;

namespace OnlineShop.Api.Controllers
{
    public class TestController : CustomBaseController
    {
        public IActionResult Test()
        {
            OnlineShopAlphaContext context = new OnlineShopAlphaContext();
            return Ok($"Test {DateTime.UtcNow}");
        }

        //[HttpGet("users")]
        public IActionResult UsersList()
        {
            IUserManagement user = new UserManagement();
            //Users x = new Users()
            //{
            //    Email = "sdklbhklugfdfkljbjklha",
            //    Address = new Addresses()
            //    {
            //        City = "sfdsfad",
            //        Country = "dafdsfsd",
            //        Phone = "dasdsfsdsa",
            //        State = "dasdsfdfds",
            //        Street = "saddfsdsad",
            //        Users = null,
            //        Zip = "asddsfsfasd"
            //    },
            //    FirstName = "dasdfsdfsd",
            //    AddressId = 5,
            //    LastName = "asddfdsfasd",
            //    Orders = null,
            //    Password = "adsfdsfsdsd",
            //    RegistrationDate = null,
            //    Username = "asddsfdfasd"
            //};

            //user.AddUser(x);

            return Ok(user.AllUsers);
        }
    }
}