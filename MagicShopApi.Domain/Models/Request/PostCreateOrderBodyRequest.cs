namespace MagicShop.Common.Models.Request
{
    public class PostCreateOrderBodyRequest
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
    }
}
