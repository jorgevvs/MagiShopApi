using MagicShop.Common.Entities.Interfaces;

namespace MagicShop.Common.Entities
{
    public class InventoryItem : IBase
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int UserId { get; set; }
    }
}
