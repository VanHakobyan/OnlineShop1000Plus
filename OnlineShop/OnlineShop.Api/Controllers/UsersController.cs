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

        /// <summary>
        /// logs in a registered user
        /// </summary>
        /// <param name="model">the login form model, from body</param>
        /// <returns>the logged-in user</returns>
        /// <response code = "200">returns the logged-in user</response>
        /// <remarks>
        /// sample request (this request logs in a registered user)\
        /// POST  /users/login\
        /// {\
        ///     "Email" : "sampleEmail",\
        ///     "Password" : "samplePassword"\
        ///}
        /// </remarks>>
        [AllowAnonymous]
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult Login([FromBody]AuthenticateModel model)
        {
            var user = _usersService.Authenticate(model.Email, model.Password);
            return Ok(user);
        }

        /// <summary>
        /// registers new user
        /// </summary>
        /// <param name="model">the register form model, from body</param>
        /// <returns>the registered user</returns>
        /// <response code = "200">returns the registered user</response>
        /// <remarks>
        /// sample request (this request registers new user)\
        /// POST  /users/register\
        /// {\
        ///     "Email" : "sampleEmail",\
        ///     "Username" : "sampleUsername",\
        ///     "FirstName" : "sampleFirstName",\
        ///     "LastName" : "sampleLastName",\
        ///     "Password" : "samplePassword",\
        ///     "ConfirmPassword" : "samplePassword",
        ///}
        /// </remarks>>
        [AllowAnonymous]
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult Register([FromBody]AuthorizeModel model)
        {
            var user = _usersService.Authorize(model.Username, model.Email, model.FirstName, model.LastName, model.Password, model.ConfirmPassword);
            return Ok(user);
        }

        /// <summary>
        /// returns all users
        /// </summary>
        /// <param name="count">count of users per page</param>
        /// <param name="page">page number</param>
        /// <returns>all registered users</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Users([FromQuery(Name = "count")]int count, [FromQuery(Name = "page")]int page)
        {
            IEnumerable<Users> users = _usersService.GetAllUsersByPage(count, page);
            return Ok(users);
        }

        /// <summary>
        /// returns a user by username
        /// </summary>
        /// <param name="username">the username to search by</param>
        /// <returns>the user with the given username</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult User([FromQuery(Name = "username")] string username)
        {
            var user = _usersService.GetUserByUsername(username);
            return Ok(user);
        }

        /// <summary>
        /// adds an address for a registered user
        /// </summary>
        /// <param name="addressModel">address form</param>
        /// <returns>address</returns>
        ///<remarks>
        /// sample request (this request adds new address)\
        /// POST  /users/address\
        /// {\
        ///     "Country" : "sampleCountry",\
        ///     "State" : "sampleState",\
        ///     "City" : "sampleCity",\
        ///     "Street" : "sampleStreet",\
        ///     "Zip" : "sampleZip",\
        ///     "Phone" : "samplePhone",
        ///}
        /// </remarks>>
        [HttpPost]
        [ProducesDefaultResponseType]
        public IActionResult Address([FromBody] Addresses addressModel)
        {
            var address = _usersService.AddAddress(addressModel.Country, addressModel.State, addressModel.City, addressModel.Street, addressModel.Zip, addressModel.Phone);
            return Ok(address);
        }
    }
}