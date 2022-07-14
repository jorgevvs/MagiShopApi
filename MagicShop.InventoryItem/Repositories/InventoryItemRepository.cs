
using MagicShop.Common.Entities;
using MagicShop.InventoryItemAPI.Contexts;
using MagicShop.InventoryItemAPI.Repositories;
using MagicShop.InventoryItemAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShopApi.InventoryItemAPI.Repositories
{
    public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        public InventoryItemRepository(InventoryItemContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        public async Task<bool> Exists(int id)
        {
            return _context.InventoryItem.Any(x => x.Id == id);
        }
    }
 }

