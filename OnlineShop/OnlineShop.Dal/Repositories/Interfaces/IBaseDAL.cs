namespace OnlineShop.Dal.Repositories.Interfaces
{
    interface IBaseDAL
    {
        OnlineShopAlphaContext DbContext { get; }
    }
}
