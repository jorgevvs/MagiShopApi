using MagicShop.Common.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicShop.Common.Entities
{
    public class Sale: Base
    {
        public int InventoryItemId { get; set; }
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsCompleted { get; set; }
    }
}
