using MagicShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShopApi.Interfaces.Repositories
{
    public interface ICardRepository : IDisposable
    {
        Task<IEnumerable<Card>> GetCards();
        ActionResult<Card> GetCardById(int cardId);
        void InsertCard(Card card);
        void UpdateCard(Card card);
        void DeleteCard(int cardId);
        void Save();
        bool Exists(int id);
    }
}
