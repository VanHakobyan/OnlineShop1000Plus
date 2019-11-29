using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common
{
    /// <summary>
    /// login with email and password
    /// </summary>
    public class AuthenticateModel
    {
        /// <summary>
        /// email of the logging-in user
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// password of the logging-in user
        /// </summary>
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Not Secure Password")]
        public string Password { get; set; }
    }
}
