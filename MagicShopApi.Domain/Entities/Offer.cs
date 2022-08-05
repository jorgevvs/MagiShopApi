using MagicShop.Common.Entities.Interfaces;
using System;

namespace MagicShop.Common.Entities
{
    public class Offer: Base
    {
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public int SaleId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }

    }
}
