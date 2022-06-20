namespace MagicShopApi.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int SaleId { get; set; }

    }
}
