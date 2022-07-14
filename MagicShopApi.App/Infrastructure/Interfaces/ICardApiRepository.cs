using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure.Interfaces
{
    public interface ICardApiRepository
    {
        Task<IEnumerable<Card>> GetCards();
        Task<Card> GetCardById(int cardId);
        Task InsertCard(Card card);
        Task UpdateCard(Card card);
        Task DeleteCard(int cardId);
    }
}
