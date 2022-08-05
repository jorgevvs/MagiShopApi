using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShop.CardAPI.Contexts
{
    public static class CardDbSeed
    {
        public async static void CardSeed(CardContext context)
        {
            try
            {
                context.Database.Migrate();

            }
            catch
            {

            }
            if (!context.Card.Any()) {

                var Cards = new List<Card>
                {
                    new Card
                    {
                        Title = "Triskaidekaphile",
                        Collection = "MID",
                        Price = 3.59m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/6/7/6750e203-1215-4203-b5b8-3f1b18940839.jpg?1634349393"
                    },
                    new Card
                    {
                        Title = "Wrenn and Seven",
                        Collection = "MID",
                        Price = 100.00m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/a/7/a7757e99-8d51-4b92-b346-6961845def24.jpg?1636225043"
                    },
                    new Card
                    {
                        Title = "Fateful Abscense",
                        Collection = "MID",
                        Price = 20,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/e/c/eca8d6f8-c6f1-437c-99e2-4281eae14a6f.jpg?1634346819"
                    },
                    new Card
                    {
                        Title = "Saw It Coming",
                        Collection = "KHM",
                        Price = 2.44m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/8/7/877a1bb9-5eae-453a-bec0-a9de20ea6815.jpg?1631047574"
                    },
                    new Card
                    {
                        Title = "Sea Gate Restoration",
                        Collection = "ZNR",
                        Price = 85.85m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/1/9/193071fe-180b-4d35-ba78-9c16675c29fc.jpg?1604250788"
                    },
                    new Card
                    {
                        Title = "Dwarven Hammer",
                        Collection = "KHM",
                        Price = 0.60m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/f/9/f9cc132f-d4c1-4bc4-9c9e-f63ab5e7d094.jpg?1631049218"
                    },
                    new Card
                    {
                        Title = "Quandrix Cultivator",
                        Collection = "STX",
                        Price = 0.74m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/e/3/e3ca9ff7-0dcf-4ecc-879c-957d290ad7f5.jpg?1624739546"
                    },
                    new Card
                    {
                        Title = "Kargan Intimidator",
                        Collection = "ZNR",
                        Price = 0.83m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/0/8/0885acdc-9b4c-4e28-8785-9e721a27e81e.jpg?1604197242"
                    },
                    new Card
                    {
                        Title = "Aether Vial",
                        Collection = "MPR",
                        Price = 163.40m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/9/3/93e26409-430b-419b-8cd2-1bce007f12d6.jpg?1656166235"
                    }

                };

                context.Card.AddRange(Cards);
                context.SaveChanges();
            }
        }
    }
}
