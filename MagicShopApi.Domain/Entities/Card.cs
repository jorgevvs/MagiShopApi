using MagicShop.Common.Entities.Interfaces;

namespace MagicShop.Common.Entities
{
    public class Card : IBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Colection { get; set; }
        public string Description { get; set; }
    }
}
