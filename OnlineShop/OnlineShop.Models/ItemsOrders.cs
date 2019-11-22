using System;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public partial class ItemsOrders
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }

        public virtual Items Item { get; set; }
        public virtual Orders Order { get; set; }
    }
}
