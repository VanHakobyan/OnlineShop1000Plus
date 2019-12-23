using OnlineShop.Common;
using OnlineShop.Common.DbModels;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    interface IBaseDAL
    {
        OnlineShopAlphaContext DbContext { get; }
    }
}
