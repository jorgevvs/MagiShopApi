using MagicShop.Common.Entities.Interfaces;
using System;

namespace MagicShop.Common.Entities
{
    public class Offer: IBase
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int SaleId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }

    }
}
