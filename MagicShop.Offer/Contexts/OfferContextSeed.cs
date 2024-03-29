﻿using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShop.OfferAPI.Contexts
{
    public static class OfferContextSeed
    {
        public async static void SeedAsync(OfferContext context)
        {
            try
            {
                context.Database.Migrate();
            }
            catch
            {

            }

            if (!context.Offer.Any())
            {
                var Offers = new List<Offer>
                {
                    new Offer
                    {
                        SaleId = 1,
                        UserId = 1, 
                        Value = 3.50m,
                        DateCreated = new DateTime(2022, 05, 30, 22, 37, 44 ),
                        IsCompleted = false
                    },
                    new Offer
                    {
                        SaleId = 2,
                        UserId = 3,
                        Value = 3.00m,
                        DateCreated = new DateTime(2022, 02, 11, 6, 12, 2 ),
                        IsCompleted = false
                    },
                    new Offer
                    {
                        SaleId = 1,
                        UserId = 1,
                        Value = 1.50m,
                        DateCreated = new DateTime(2022, 03, 10, 13, 30, 5 ),
                        IsCompleted = false
                    },
                    new Offer
                    {
                        SaleId = 1,
                        UserId = 2,
                        Value = 5.00m,
                        DateCreated = new DateTime(2022, 07, 20, 8, 25, 13 ),
                        IsCompleted = false
                    },

                };

                context.Offer.AddRange(Offers);
                context.SaveChanges();
            }

        }
    }
}
