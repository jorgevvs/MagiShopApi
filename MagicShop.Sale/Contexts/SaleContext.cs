
using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.SaleAPI.Contexts
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options) { }

        public DbSet<Sale> Sale { get; set; }
    }
}
