using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.DbModels
{
    /// <summary>
    /// to specify a category for a group of products
    /// </summary>
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
