using MagicShop.Common.Entities;
using System;
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
                        InventoryItemId = 1,
                        RequestedValue = 4.77m,
                        UserId = 1,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    },
                    new Sale
                    {
                        InventoryItemId = 1,
                        RequestedValue = 5.22m,
                        UserId = 2,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    },
                    new Sale
                    {
                        InventoryItemId = 3,
                        RequestedValue = 5.00m,
                        UserId = 1,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    },
                    new Sale
                    {
                        InventoryItemId = 4,
                        RequestedValue = 6,
                        UserId = 1,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    }
                };

                context.Sale.AddRange(Sales);
                context.SaveChanges();
            }
        }
    }
}
