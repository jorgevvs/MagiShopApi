using MagicShopApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicShopApi.Contexts
{
    public class MagicShopContext : DbContext
    {
        public MagicShopContext(DbContextOptions<MagicShopContext> options) : base(options) { }

        public DbSet<Offer> Offer { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<User> User { get; set; }

    }
}
