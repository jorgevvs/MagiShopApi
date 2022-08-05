using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShop.InventoryItemAPI.Contexts
{
    public static class InventoryItemContextSeed
    {
        public async static void SeedAsync(InventoryItemContext context)
        {
            try
            {
                context.Database.Migrate();

            }
            catch
            {

            }

            if (!context.InventoryItem.Any())
            {
                var InventoryItems = new List<InventoryItem>
                {
                    new InventoryItem
                    {
                        CardId = 1,
                        UserId = 1,
                        Quality = "N"
                    },
                    new InventoryItem
                    {
                        CardId = 1,
                        UserId = 2,
                        Quality = "NM"
                    },
                    new InventoryItem
                    {
                        CardId = 3,
                        UserId = 1,
                        Quality = "NM"
                    },
                    new InventoryItem
                    {
                        CardId = 5,
                        UserId = 1,
                        Quality = "SP"
                    }
                };
                context.InventoryItem.AddRange(InventoryItems);
                context.SaveChanges();
            }

        }
    }
}
