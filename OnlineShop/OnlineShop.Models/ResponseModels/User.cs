using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.ResponseModels
{
    public class User
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }
    }
}
