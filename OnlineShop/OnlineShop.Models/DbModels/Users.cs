using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common
{
    /// <summary>
    /// user specific data
    /// </summary>
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }
        [Key]
        public int Id { get; set; }
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
        
        [DataType(DataType.Password, ErrorMessage ="Not Secure Password")]
        [Required]
        public string Password { get; set; }
        
        public DateTime? RegistrationDate { get; set; }
        public int? AddressId { get; set; }
        public string Token { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
