using System.ComponentModel.DataAnnotations.Schema;

namespace MagicShopApi.Models.DTO
{
    public class OfferDTO
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        [ForeignKey(nameof(SaleId))]
        public int SaleId { get; set; }
    }
}
