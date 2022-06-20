using MagicShopApi.Contexts;
using MagicShopApi.Interfaces.Repositories;
using MagicShopApi.Models;
using MagicShopApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShopApi.Repositories
{
    public class OfferRepository : IOfferRepository, IDisposable
    {
        private readonly MagicShopContext _context;
        private readonly IMemoryCache _cache;

        public OfferRepository(MagicShopContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache; 
        }

        public void DeleteOffer(int offerId)
        {
            Offer offer = _context.Offer.Find(offerId);
            _context.Offer.Remove(offer);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Exists(int offerId)
        {
            return _context.Offer.Any(x => x.Id == offerId);
        }

        public ActionResult<Offer> GetOfferById(int offerId)
        {
            var offer = _cache.GetOrCreate("Offers_GetById_" + offerId, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.Offer.Find(offerId);
            });
            return offer;
        }

        public async Task<IEnumerable<Offer>> GetOffers()
        {
            var offers = _cache.GetOrCreate("Offers_GetAll", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.Offer.ToListAsync();
            });
            return await offers;
        }

        public void InserOffer(Offer offer)
        {
            _context.Offer.Add(offer);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateOffer(Offer offer)
        {
            _context.Entry(offer).State = EntityState.Modified;
        }
    }
}
