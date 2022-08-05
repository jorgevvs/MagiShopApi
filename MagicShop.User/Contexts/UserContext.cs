
using MagicShop.Common.Entities;
using MagicShop.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.UserAPI.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBase<User>();
            var builder = modelBuilder.Entity<User>();
            builder.Property(c => c.Name)
                .HasMaxLength(40)
                .IsRequired(true);

            builder.Property(c => c.Balance)
                .HasColumnType("decimal(10,2)")
                .IsRequired(true);
        }
    }
}
