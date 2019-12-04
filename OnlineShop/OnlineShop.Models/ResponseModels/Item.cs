using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.ResponseModels
{
    public class Item
    {
        public int? Color { get; set; }
        public int? Size { get; set; }
        public int? Quantity { get; set; }
        public string Image { get; set; }
    }
}
