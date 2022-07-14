
using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.CardAPI.Contexts
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options) { }

        public DbSet<Card> Card { get; set; }
    }
}
