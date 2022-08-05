
using MagicShop.Common.Entities;
using MagicShop.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.CardAPI.Contexts
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options) {
            Database.EnsureCreated();
        }
        public DbSet<Card> Card { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBase<Card>();
            var builder = modelBuilder.Entity<Card>();
            builder.Property(c => c.Title)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(c => c.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired(true);

            builder.Property(c => c.Image)
                .HasMaxLength(300)
                .IsRequired(true);

            builder.Property(c => c.Collection)
                .HasMaxLength(4)
                .IsRequired(true);

        }
    }
}
