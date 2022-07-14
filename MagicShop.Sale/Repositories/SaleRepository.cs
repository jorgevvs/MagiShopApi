using MagicShop.CardAPI.Repositories;
using MagicShop.Common.Entities;
using MagicShop.SaleAPI.Contexts;
using MagicShop.SaleAPI.Repositories.Interfaces;
using MagicShop.UserAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShop.SaleAPI.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        public SaleRepository(SaleContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        public bool Exists(int saleId)
        {
            return _context.Sale.Any(x => x.Id == saleId);
        }

    }
}
