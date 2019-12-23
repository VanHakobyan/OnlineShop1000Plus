using OnlineShop.Common.DbModels;
using OnlineShop.Common.ResponseModels;

namespace OnlineShop.Common.Factories
{
    public class UserFactory
    {
        public dynamic GetUserModel(string securityLevel)
        {
            if (securityLevel == "secure")
            {
                return new User();
            }
            return new Users();
        }
    }
}
