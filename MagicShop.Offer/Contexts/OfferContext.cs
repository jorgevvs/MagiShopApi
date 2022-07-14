
using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.OfferAPI.Contexts
{
    public class OfferContext : DbContext
    {
        public OfferContext(DbContextOptions<OfferContext> options) : base(options) { }
        public DbSet<Offer> Offer { get; set; }
    }
}
