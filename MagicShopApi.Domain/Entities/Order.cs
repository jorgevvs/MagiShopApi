using MagicShop.Common.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MagicShop.Common.Entities
{
    public class Order : IBase
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }
    }
}
