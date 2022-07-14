
using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.UserAPI.Contexts
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

    }
}
