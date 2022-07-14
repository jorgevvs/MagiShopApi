using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MagicShop.InventoryItemAPI.Contexts
{
    public class InventoryItemContextSeed
    {
        public static void SeedAsync(InventoryItemContext context)
        {
            if (!context.InventoryItem.Any())
            {
                var InventoryItems = new List<InventoryItem>
                {
                    new InventoryItem
                    {
                        CardId = 1,
                        UserId = 1
                    },
                    new InventoryItem
                    {
                        CardId = 1,
                        UserId = 2
                    },
                    new InventoryItem
                    {
                        CardId = 3,
                        UserId = 1
                    },
                    new InventoryItem
                    {
                        CardId = 5,
                        UserId = 1
                    }
                };
                context.InventoryItem.AddRange(InventoryItems);
                context.SaveChanges();
            }

        }
    }
}
