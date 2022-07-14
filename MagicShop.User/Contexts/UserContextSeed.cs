using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MagicShop.UserAPI.Contexts
{
    public class UserContextSeed
    {
        public static void SeedAsync(UserContext context)
        {
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
