using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MagicShop.SaleAPI.Contexts
{
    public class SaleContextSeed
    {
        public static void SeedAsync(SaleContext context)
        {
            if (!context.Sale.Any())
            {
                var Sales = new List<Sale>
                {
                    new Sale
                    {
                        CardId = 1,
                        RequestedValue = 4.77m,
                        UserId = 1
                    },
                    new Sale
                    {
                        CardId = 1,
                        RequestedValue = 5.22m,
                        UserId = 2
                    },
                    new Sale
                    {
                        CardId = 3,
                        RequestedValue = 5.00m,
                        UserId = 1
                    },
                    new Sale
                    {
                        CardId = 5,
                        RequestedValue = 6,
                        UserId = 1
                    }
                };

                context.Sale.AddRange(Sales);
                context.SaveChanges();
            }
        }
    }
}
