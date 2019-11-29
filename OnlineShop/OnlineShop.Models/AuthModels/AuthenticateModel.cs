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
        public string Email { get; set; }

        /// <summary>
        /// password of the logging-in user
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
