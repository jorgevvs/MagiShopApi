
using MagicShop.CardAPI.Contexts;
using MagicShop.CardAPI.Repositories.Interfaces;
using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShop.CardAPI.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository, IDisposable
    {
        public CardRepository(CardContext context, IMemoryCache memoryCache) : base(context, memoryCache) { }

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

        public async Task<bool>Exists(int id)
        {
            return _context.Card.Any(x => x.Id == id);
        }

    }
}
