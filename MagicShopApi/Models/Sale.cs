using System.Collections.Generic;

namespace MagicShopApi.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
    }
}
