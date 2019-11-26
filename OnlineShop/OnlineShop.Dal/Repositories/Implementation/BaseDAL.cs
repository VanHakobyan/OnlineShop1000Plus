using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;

namespace OnlineShop.Dal.Repositories.Implementation
{
    public class BaseDAL : IBaseDAL
    {
        public OnlineShopAlphaContext DbContext { get; }
        public BaseDAL(OnlineShopAlphaContext dbContext)
        {
            DbContext = dbContext;
        }

    }
}
