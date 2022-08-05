using MagicShop.Common.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicShop.Common.Entities
{
    public class InventoryItem : Base
    {
        [ForeignKey("Card")]
        public int CardId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Quality { get; set; }
    }
}
