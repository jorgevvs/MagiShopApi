namespace MagicShop.Common.Models.Response
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
    }
}
