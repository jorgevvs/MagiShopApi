
using MagicShop.Common.Entities;
using MagicShop.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.OfferAPI.Contexts
{
    public class OfferContext : DbContext
    {
        public OfferContext(DbContextOptions<OfferContext> options) : base(options) { }
        public DbSet<Offer> Offer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBase<Offer>();
            var builder = modelBuilder.Entity<Offer>();

            builder.Property(c => c.IsCompleted)
                .HasColumnType("bit")
                .IsRequired(true);

            builder.Property(c => c.UserId)
                .HasColumnType("int")
                .IsRequired(true);

            builder.Property(c => c.SaleId)
                .HasColumnType("int")
                .IsRequired(true);

            builder.Property(c => c.DateCreated)
                .HasColumnType("DateTime")
                .IsRequired(true);

            builder.Property(c => c.Value)
                    .HasColumnType("decimal(10,2)")
                    .IsRequired(true);

        }
    }

    
}
