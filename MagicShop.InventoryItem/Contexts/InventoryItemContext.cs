
using MagicShop.Common.Entities;
using MagicShop.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.InventoryItemAPI.Contexts
{
    public class InventoryItemContext : DbContext
    {
        public InventoryItemContext(DbContextOptions<InventoryItemContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<InventoryItem> InventoryItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBase<InventoryItem>();
            var builder = modelBuilder.Entity<InventoryItem>();
            builder.Property(c => c.CardId)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(c => c.Quality)
                .IsRequired()
                .HasMaxLength(9);
        }
    }
}
