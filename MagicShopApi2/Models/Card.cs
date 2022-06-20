namespace MagicShopApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Colection { get; set; }
        public string Description { get; set; }
    }
}
