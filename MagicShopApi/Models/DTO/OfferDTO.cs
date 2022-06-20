namespace MagicShopApi.Models.DTO
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int SaleId { get; set; }
    }
}
