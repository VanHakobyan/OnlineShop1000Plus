using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common
{
    /// <summary>
    /// to describe a product's general characteristics
    /// </summary>
    public partial class Products
    {
        public Products()
        {
            Items = new HashSet<Items>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
