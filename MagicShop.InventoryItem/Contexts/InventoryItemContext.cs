
using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.InventoryItemAPI.Contexts
{
    public class InventoryItemContext : DbContext
    {
        public InventoryItemContext(DbContextOptions<InventoryItemContext> options) : base(options) { }

        public DbSet<InventoryItem> InventoryItem { get; set; }

    }
}
