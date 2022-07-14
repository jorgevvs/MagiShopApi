using MagicShop.Common.Entities.Interfaces;

namespace MagicShop.Common.Entities
{
    public class Offer: IBase
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int SaleId { get; set; }

    }
}
