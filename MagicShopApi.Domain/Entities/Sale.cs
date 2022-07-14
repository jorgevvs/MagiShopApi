using MagicShop.Common.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicShop.Common.Entities
{
    public class Sale: IBase
    {
        public int Id { get; set; }

        public int CardId { get; set; }

        public int UserId { get; set; }
        public decimal RequestedValue { get; set; }

    }
}
