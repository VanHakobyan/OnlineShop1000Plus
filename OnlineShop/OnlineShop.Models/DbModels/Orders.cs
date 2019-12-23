using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.DbModels
{
    /// <summary>
    /// to summorize an order's details
    /// </summary>
    public partial class Orders
    {
        public Orders()
        {
            ItemsOrders = new HashSet<ItemsOrders>();
        }

        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<ItemsOrders> ItemsOrders { get; set; }
    }
}
