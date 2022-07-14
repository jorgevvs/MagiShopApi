using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MagicShop.OfferAPI.Contexts
{
    public class OfferContextSeed
    {
        public static void SeedAsync(OfferContext context)
        {
            if (!context.Offer.Any())
            {
                var Offers = new List<Offer>
                {
                    new Offer
                    {
                        Id = 1,
                        SaleId = 1,
                        UserId = 1, 
                        Value = 3.50m,
                    },
                    new Offer
                    {
                        Id = 2,
                        SaleId = 2,
                        UserId = 3,
                        Value = 3.00m,
                    },
                    new Offer
                    {
                        Id = 3,
                        SaleId = 1,
                        UserId = 1,
                        Value = 1.50m,
                    },
                    new Offer
                    {
                        Id = 4,
                        SaleId = 1,
                        UserId = 2,
                        Value = 5.00m,
                    },

                };

                context.Offer.AddRange(Offers);
                context.SaveChanges();
            }

        }
    }
}
