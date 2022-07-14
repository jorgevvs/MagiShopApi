using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MagicShop.CardAPI.Contexts
{
    public class CardContextSeed
    {
        public static void SeedAsync(CardContext context)
        {
            if (!context.Card.Any())
            {
                var Cards = new List<Card>
                {
                    new Card
                    {
                        Title = "Triskaidekaphile",
                        Description = "You have no maximum hand size. At the beginning of your upkeep, if you have exactly thirteen cards in your hand, you win the game.",
                        Colection = "MID",
                        Price = 3.59m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/6/7/6750e203-1215-4203-b5b8-3f1b18940839.jpg?1634349393"
                    },
                    new Card
                    {
                        Title = "Wrenn and Seven",
                        Description = "+1: Reveal the top four cards of your library. Put all land cards revealed this way into your hand and the rest into your graveyard." +
                                        "0: Put any number of land cards from your hand onto the battlefield tapped." +
                                       "−3: Create a green Treefolk creature token with reach and “This creature’s power and toughness are each equal to the number of lands you control." +
                                        "−8: Return all permanent cards from your graveyard to your hand. You get an emblem with “You have no maximum hand size.”",
                        Colection = "MID",
                        Price = 100.00m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/a/7/a7757e99-8d51-4b92-b346-6961845def24.jpg?1636225043"
                    },
                    new Card
                    {
                        Title = "Fateful Abscense",
                        Description = "Destroy target creature or planeswalker. Its controller investigates.",
                        Colection = "MID",
                        Price = 20,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/e/c/eca8d6f8-c6f1-437c-99e2-4281eae14a6f.jpg?1634346819"
                    },
                    new Card
                    {
                        Title = "Saw It Coming",
                        Description = "Counter target spell.",
                        Colection = "KHM",
                        Price = 2.44m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/8/7/877a1bb9-5eae-453a-bec0-a9de20ea6815.jpg?1631047574"
                    },
                    new Card
                    {
                        Title = "Sea Gate Restoration",
                        Description = "Draw cards equal to the number of cards in your hand plus one. You have no maximum hand size for the rest of the game.",
                        Colection = "ZNR",
                        Price = 85.85m,
                        Image = "https://c1.scryfall.com/file/scryfall-cards/large/front/1/9/193071fe-180b-4d35-ba78-9c16675c29fc.jpg?1604250788"
                    }
                };

                context.Card.AddRange(Cards);
                context.SaveChanges();
            }
        }
    }
}
