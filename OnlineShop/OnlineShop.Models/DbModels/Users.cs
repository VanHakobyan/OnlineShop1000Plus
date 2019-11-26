using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password, ErrorMessage ="Not Secure Password")]
        public string Password { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? AddressId { get; set; }
        public string Token { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
