using MagicShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicShop.OrderAPI.Contexts
{
    public class OrderContextSeed
    {
        public static void SeedAsync(OrderContext context)
        {
            if (!context.Order.Any())
            {
                var Orders = new List<Order>
                {
                    new Order
                    {
                        CardId = 1,
                        RequestedValue = 4.77m,
                        UserId = 1,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    },
                    new Order
                    {
                        CardId = 1,
                        RequestedValue = 5.22m,
                        UserId = 2,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    },
                    new Order
                    {
                        CardId = 3,
                        RequestedValue = 5.00m,
                        UserId = 1,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    },
                    new Order
                    {
                        CardId = 5,
                        RequestedValue = 6,
                        UserId = 1,
                        IsCompleted = false,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                    }
                };

                context.Order.AddRange(Orders);
                context.SaveChanges();
            }
        }
    }
}
