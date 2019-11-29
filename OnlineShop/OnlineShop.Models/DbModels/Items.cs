using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OnlineShop.Common
{
   /// <summary>
   /// to specify a certain item of a product
   /// </summary>
    public partial class Items
    {
        public Items()
        {
            ItemsOrders = new HashSet<ItemsOrders>();
        }

        [Key]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Color { get; set; }
        public int? Size { get; set; }
        public int? Quantity { get; set; }
        public string Image { get; set; }

        public virtual Products Product { get; set; }
        public virtual ICollection<ItemsOrders> ItemsOrders { get; set; }
    }
}
