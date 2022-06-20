using System.ComponentModel.DataAnnotations.Schema;

namespace MagicShopApi.Models.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }

        [ForeignKey(nameof(CardId))]
        public int CardId { get; set; }
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
    }
}
