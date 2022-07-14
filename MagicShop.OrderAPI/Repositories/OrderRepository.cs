using MagicShop.Common.Entities;
using MagicShop.OrderAPI.Contexts;
using MagicShop.SaleAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context, IMemoryCache cache) : base(context, cache)
        {
        }

        public bool Exists(int saleId)
        {
            return _context.Order.Any(x => x.Id == saleId);
        }

    }
}
