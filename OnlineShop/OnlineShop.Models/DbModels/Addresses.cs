using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common
{
    /// <summary>
    /// to add a new address for a registered user
    /// </summary>
    public partial class Addresses
    {
        public Addresses()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
