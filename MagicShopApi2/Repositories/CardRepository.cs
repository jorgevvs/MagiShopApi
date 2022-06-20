using MagicShopApi.Contexts;
using MagicShopApi.Interfaces.Repositories;
using MagicShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShopApi.Repositories
{
    public class CardRepository : ICardRepository, IDisposable
    {
        private readonly MagicShopContext _context;
        private readonly IMemoryCache _cache;

        public CardRepository(MagicShopContext context, IMemoryCache memoryCache)
        {
            this._context = context;
            _cache = memoryCache;
        }

        public void DeleteCard(int cardId)
        {
            Card card = _context.Card.Find(cardId);
            _context.Card.Remove(card);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Exists(int id)
        {
            return _context.Card.Any(x => x.Id == id);
        }

        public ActionResult<Card> GetCardById(int cardId)
        {
            var card = _cache.GetOrCreate("Cards_GetById_" + cardId, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.Card.Find(cardId);
            });
            return card;
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            var cards = _cache.GetOrCreate("Cards_GetAll", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(3);
                entry.SetPriority(CacheItemPriority.High);
                System.Threading.Thread.Sleep(2000);
                return _context.Card.ToListAsync();
            });

            return await cards;
        }

        public void InsertCard(Card card)
        {
            _context.Card.Add(card);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateCard(Card card)
        {
            _context.Entry(card).State = EntityState.Modified;
        }
    }
}
