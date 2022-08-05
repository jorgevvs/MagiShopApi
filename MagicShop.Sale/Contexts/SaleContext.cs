
using MagicShop.Common.Entities;
using MagicShop.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.SaleAPI.Contexts
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options) { }

        public DbSet<Sale> Sale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBase<Sale>();
            var builder = modelBuilder.Entity<Sale>();
            builder.Property(c => c.IsCompleted)
                .HasColumnType("bit")
                .IsRequired(true);

            builder.Property(c => c.RequestedValue)
                .HasColumnType("decimal(10,2)")
                .IsRequired(true);

            builder.Property(c => c.UserId)
                .HasColumnType("int")
                .IsRequired(true);

            builder.Property(c => c.DateCreated)
                .HasColumnType("DateTime")
                .IsRequired(true);

            builder.Property(c => c.UserId)
                .HasColumnType("int")
                .IsRequired(true);

            builder.Property(c => c.InventoryItemId)
                .HasColumnType("int")
                .IsRequired(true);

        }
    }
}
