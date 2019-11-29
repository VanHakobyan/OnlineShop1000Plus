using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common
{
    /// <summary>
    /// registering new user
    /// </summary>
    public class AuthorizeModel
    {
        /// <summary>
        /// email of the new user
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        /// <summary>
        /// username of the new user
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        
        /// <summary>
        /// first name of the new user
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        /// <summary>
        /// last name of the new user
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        /// <summary>
        /// password of the new user
        /// </summary>
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Not Secure Password")]
        public string Password { get; set; }
        
        /// <summary>
        /// password confirmation for the new user
        /// </summary>
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Not Secure Password")]
        public string ConfirmPassword { get; set; }
    }
}
