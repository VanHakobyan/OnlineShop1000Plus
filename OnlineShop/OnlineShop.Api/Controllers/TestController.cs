using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Bll.Repositories;
using OnlineShop.Dal;
using OnlineShop.Models;

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
            IUserManagementBLL user = new UserManagementBLL();
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