using MagicShop.Common.Entities.Interfaces;

namespace MagicShop.Common.Entities
{
    public class Card : Base
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Collection { get; set; }
    }
}
