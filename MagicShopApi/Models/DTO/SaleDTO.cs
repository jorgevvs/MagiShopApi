namespace MagicShopApi.Models.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
    }
}
