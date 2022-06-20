using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicShopApi.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [ForeignKey(nameof(CardId))]
        public int CardId { get; set; }
        public Card Card { get; set; }

        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal RequestedValue { get; set; }

    }
}
