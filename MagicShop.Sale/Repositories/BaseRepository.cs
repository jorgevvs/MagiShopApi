using MagicShop.Common.Entities.Interfaces;
using MagicShop.SaleAPI.Constants;
using MagicShop.SaleAPI.Contexts;
using MagicShop.SaleAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.SaleAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBase
    {
        protected readonly SaleContext _context;
        protected readonly IMemoryCache _cache;

        public BaseRepository(SaleContext context, IMemoryCache memoryCache)
        {
            this._context = context;
            _cache = memoryCache;
        }
        public async Task Save(int id = 0)
        {
            await _context.SaveChangesAsync();
            await CleanCache($"{CacheConstant.saleByIdKey}{id}",CacheConstant.allSalesKey);
        }
        public async Task CleanCache(params string[] removeStrings)
        {
            foreach(var removeString in removeStrings)
            {
                _cache.Remove(removeString);
            }
        }

        public async Task Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await Save(obj.Id);
        }
        public async Task Delete(int id)
        {
            var obj = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(obj);
            await Save(obj.Id);
        }
        public async Task<T> GetById(int id, string cacheId = CacheConstant.saleByIdKey)
        {
            return await _cache.GetOrCreateAsync<T>(cacheId + id, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return Task.FromResult(_context.Set<T>().Find(id));
            });
        }
        public async Task<IEnumerable<T>> GetAll(string cacheId = CacheConstant.allSalesKey)
        {
            return await _cache.GetOrCreateAsync(cacheId, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(3);
                entry.SetPriority(CacheItemPriority.High);
                System.Threading.Thread.Sleep(2000);
                return _context.Set<T>().ToListAsync();
            });
        }
        public async Task Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            await Save(obj.Id);
        }
    }
}
