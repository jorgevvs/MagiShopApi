using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.OrderAPI.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

        public DbSet<Order> Order { get; set; }
    }
}
