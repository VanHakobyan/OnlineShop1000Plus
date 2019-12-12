using Microsoft.EntityFrameworkCore;
using OnlineShop.Common;
using OnlineShop.Dal.Repositories.Interfaces;
using OnlineShop.Dal.Repositories.Implementation;

namespace OnlineShop.Dal
{
    public class OnlineShopDAL
    {
        private OnlineShopAlphaContext _dbContext;
        private readonly DbContextOptions<OnlineShopAlphaContext> _options;

        public OnlineShopDAL(DbContextOptions<OnlineShopAlphaContext> options)
        {
            _options = options;
        }
        private OnlineShopAlphaContext DbContext => _dbContext ?? (_dbContext = new OnlineShopAlphaContext(_options));

        private IUserManagementDAL _userManagementDAL;
        public IUserManagementDAL UserManagementDAL => _userManagementDAL ?? (_userManagementDAL = new UserManagementDAL(DbContext));

        private IProductManagementDAL _productManagementDAL;
        public IProductManagementDAL ProductManagementDAL => _productManagementDAL ?? (_productManagementDAL = new ProductManagementDAL(DbContext));

        private IItemsManagementDAL _itemsManagementDAL;
        public IItemsManagementDAL ItemsManagementDAL => _itemsManagementDAL ?? (_itemsManagementDAL = new ItemsManagementDAL(DbContext));

        private IAddressManagementDAL _addressManagementDAL;
        public IAddressManagementDAL AddressManagementDAL => _addressManagementDAL ?? (_addressManagementDAL = new AddressManagementDAL(DbContext));

        private ICategoryManagementDAL _categoryManagementDAL;
        public ICategoryManagementDAL categoryManagementDAL => _categoryManagementDAL ?? (_categoryManagementDAL = new CategoryManagementDAL(DbContext));

        private ICartManagementDAL _cartManagementDAL;
        public ICartManagementDAL CartManagementDAL => _cartManagementDAL ?? (_cartManagementDAL = new CartManagementDAL(DbContext));
    }
}
