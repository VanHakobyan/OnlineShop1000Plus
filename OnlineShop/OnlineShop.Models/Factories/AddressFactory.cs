using OnlineShop.Common.DbModels;
using OnlineShop.Common.ResponseModels;

namespace OnlineShop.Common.Factories
{
    public class AddressFactory
    {
        public dynamic GetAddressModel(string securityLevel)
        {
            if (securityLevel == "secure")
            {
                return new Address();
            }
            return new Addresses();
        }
    }
}
