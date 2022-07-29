namespace MagicShop.Common.Models.Request
{
    public class PutMatchOrderWithSaleBodyRequest
    {
        public int OrderId { get; set; }
        public int SaleId { get; set; }
        public int ItemId { get; set; }
    }
}
