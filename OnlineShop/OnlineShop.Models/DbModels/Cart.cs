namespace OnlineShop.Common.DbModels
{
    /// <summary>
    /// all the items in the cart per user
    /// </summary>
    public partial class Cart
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ItemId { get; set; }

        public virtual Items Item { get; set; }
        public virtual Users User { get; set; }
    }
}
