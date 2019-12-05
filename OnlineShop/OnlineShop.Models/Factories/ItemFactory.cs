using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common.ResponseModels;

namespace OnlineShop.Common.Factories
{
    public class ItemFactory
    {
        public dynamic GetItemModel(string securityLevel)
        {
            if (securityLevel == "secure")
            {
                return new Item();
            }
            return new Items();
        }
    }
}
