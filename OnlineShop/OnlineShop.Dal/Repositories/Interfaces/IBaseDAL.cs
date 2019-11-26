using OnlineShop.Common;

namespace OnlineShop.Dal.Repositories.Interfaces
{
    interface IBaseDAL
    {
        OnlineShopAlphaContext DbContext { get; }
    }
}
