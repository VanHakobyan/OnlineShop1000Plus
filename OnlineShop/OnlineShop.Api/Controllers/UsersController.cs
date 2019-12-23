using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Api.Services.Interfaces;
using System.Collections.Generic;
using OnlineShop.Api.Helpers;
using OnlineShop.Common.AuthModels;
using OnlineShop.Common.DbModels;
using Serilog;

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
            try
            {
                var user = _usersService.Authenticate(model.Email, model.Password);
                if (user == null)
                {
                    return BadRequest("Email and/or password missing!");
                }
                if (!EmailValidation.IsValidEmail(user.Email))
                {
                    return BadRequest("Email not valid!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.Login() method!");
                return NotFound();
            }
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
        ///     "Username" : "sampleUsername",\
        ///     "Email" : "sampleEmail",\
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
            try
            {
                var user = _usersService.Authorize(model.Username, model.Email, model.FirstName, model.LastName, model.Password, model.ConfirmPassword);
                if (user == null)
                {
                    return BadRequest("User not specified!");
                }
                else if (!EmailValidation.IsValidEmail(user.Email))
                {
                    return BadRequest("Email not valid!");
                }
                else if (model.Password != model.ConfirmPassword)
                {
                    return BadRequest("Password not confirmed!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.Register() method!");
                return NotFound();
            }
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
            try
            {
                IEnumerable<Users> users = _usersService.GetAllUsersByPage(count, page);
                if (users == null)
                {
                    return NotFound("Users not found!");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.Users() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// returns a user by username
        /// </summary>
        /// <param name="username">the username to search by</param>
        /// <returns>the user with the given username</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public new IActionResult User([FromQuery(Name = "username")] string username)
        {
            try
            {
                var user = _usersService.GetUserByUsername(username);
                if (user == null)
                {
                    return NotFound("User not found!");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.User() method!");
                return NotFound();
            }
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
        public IActionResult AddAddress([FromBody] Addresses addressModel)
        {
            try
            {
                var address = _usersService.AddAddress(addressModel.Country, addressModel.State, addressModel.City, addressModel.Street, addressModel.Zip, addressModel.Phone);
                if (address == null)
                {
                    return BadRequest("Address not specified!");
                }
                return Ok(address);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.AddAddress() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// gets the address by Id
        /// </summary>
        /// <param name="id">address Id</param>
        /// <returns>address if found</returns>
        [HttpGet]
        [ProducesDefaultResponseType]
        public IActionResult Address([FromQuery(Name = "id")] int id)
        {
            try
            {
                var address = _usersService.GetAddressById(id);
                if (address == null)
                {
                    return BadRequest("Address not found!");
                }
                return Ok(address);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.Address() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// updates existing address
        /// </summary>
        /// <param name="addressId">id of the address to be updated</param>
        /// <param name="address">model for update info</param>
        /// <remarks>
        /// sample request (this request adds new address)\
        /// PUT  /users/updateAddress\
        /// {\
        ///     "Country" : "sampleCountry",\
        ///     "State" : "sampleState",\
        ///     "City" : "sampleCity",\
        ///     "Street" : "sampleStreet",\
        ///     "Zip" : "sampleZip",\
        ///     "Phone" : "samplePhone",
        ///}
        /// </remarks>>
        [HttpPut]
        [ProducesDefaultResponseType]
        public IActionResult UpdateAddress([FromQuery(Name = "addressId")] int addressId, [FromBody] Addresses address)
        {
            try
            {
                var oldAddress = _usersService.GetAddressById(addressId);
                if (oldAddress == null)
                {
                    return BadRequest("Address not found!");
                }
                if (address == null)
                {
                    return BadRequest("Update info missing!");
                }
                _usersService.UpdateAddress(oldAddress);
                oldAddress.Country = address.Country;
                oldAddress.City = address.City;
                oldAddress.State = address.State;
                oldAddress.Street = address.Street;
                oldAddress.Zip = address.Zip;
                oldAddress.Phone = address.Phone;
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.UpdateAddress() method!");
                return NotFound();
            }
        }

        /// <summary>
        /// deletes existing address
        /// </summary>
        /// <param name="id">id of the address to be deleted</param>
        [HttpDelete]
        [ProducesDefaultResponseType]
        public IActionResult RemoveAddress([FromQuery(Name = "id")] int id)
        {
            try
            {
                var adress = _usersService.GetAddressById(id);
                if (adress == null)
                {
                    return BadRequest("Address not found!");
                }
                _usersService.RemoveAddress(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.RemoveAddress() method!");
                return NotFound();
            }
        }


        /// <summary>
        /// attached address to an existing user
        /// </summary>
        /// <param name="addressId">id of the address to be attached</param>
        /// <param name="userId">id of the user of the address</param>
        /// <returns>updated user with address Id</returns>
        [HttpPatch]
        [ProducesDefaultResponseType]
        public IActionResult UpdateUserByAddress([FromQuery(Name = "addressId")] int addressId, [FromQuery(Name = "userId")]  int userId)
        {
            try
            {
                var user = _usersService.GetUserById(userId);
                if (user == null)
                {
                    return BadRequest("User not found!");
                }
                user.AddressId = addressId;
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, "Exception in OnlineShop.Api.Controllers.UsersController.UpdateUserByAddress() method!");
                return NotFound();
            }
        }
    }
}