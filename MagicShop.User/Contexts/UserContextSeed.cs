using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShop.UserAPI.Contexts
{
    public static class UserContextSeed
    {
        public async static void SeedAsync(UserContext context)
        {
            try
            {
                context.Database.Migrate();

            }
            catch
            {

            }

            if (!context.User.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Name = "Jorge",
                        Balance = 500.00m
                    },
                    new User
                    {
                        Name = "Matias",
                        Balance = 1500.00m
                    },
                    new User
                    {
                        Name = "Carol",
                        Balance = 300.00m
                    },
                    new User
                    {
                        Name = "Raquel",
                        Balance = 2000.00m
                    }
                };

                context.User.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
