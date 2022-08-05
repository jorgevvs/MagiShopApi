using MagicShop.Common.Entities;
using MagicShop.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.OrderAPI.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBase<Order>();
            var builder = modelBuilder.Entity<Order>();
            builder.Property(c => c.CardId)
                .HasColumnType("int")
                .IsRequired(true);
            
            builder.Property(c => c.UserId)
                .HasColumnType("int")
                .IsRequired(true);

            builder.Property(c => c.RequestedValue)
                .HasColumnType("decimal(10,2)")
                .IsRequired(true);

            builder.Property(c => c.IsCompleted)
                .HasColumnType("bit")
                .IsRequired(true);

            builder.Property(c => c.DateCreated)
                .HasColumnType("DateTime")
                .IsRequired(true);

        }
    }
}
