using OnlineShop.Common.DbModels;
using OnlineShop.Common.ResponseModels;

namespace OnlineShop.Common.Factories
{
    public class ProductFactory
    {
        public dynamic GetProductModel(string securityLevel)
        {
            if (securityLevel == "secure")
            {
                return new Product();
            }
            return new Products();
        }
    }
}
