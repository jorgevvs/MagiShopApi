using MagicShopApi.Contexts;
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
    public class InventoryItemRepository : IInventoryItemRepository, IDisposable
    {
        private readonly MagicShopContext _context;
        private readonly IMemoryCache _cache;

        public InventoryItemRepository(MagicShopContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public void DeleteInventoryItem(int inventoryItemId)
        {
            InventoryItem inventoryItem = _context.InventoryItem.Find(inventoryItemId);
            _context.InventoryItem.Remove(inventoryItem);
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
            return _context.InventoryItem.Any(x => x.Id == id);
        }

        public ActionResult<InventoryItem> GetInventoryItemById(int inventoryItemId)
        {
            var inventoryItem = _cache.GetOrCreate("InventoryItems_GetById_" + inventoryItemId, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.InventoryItem.Find(inventoryItemId);
            });
            return inventoryItem;
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoryItems()
        {
            var inventoryItem = _cache.GetOrCreate("InventoryItems_GetAll", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.InventoryItem.ToListAsync();
            });
            return await inventoryItem;
        }

        public void InsertInventoryItem(InventoryItem inventoryItem)
        {
            _context.InventoryItem.Add(inventoryItem);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            _context.Entry(inventoryItem).State = EntityState.Modified;
        }
    }
 }

