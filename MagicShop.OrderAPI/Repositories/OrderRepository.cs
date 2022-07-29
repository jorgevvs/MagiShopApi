using MagicShop.Common.Entities;
using MagicShop.Common.Models.Response;
using MagicShop.OrderAPI.Contexts;
using MagicShop.OrderAPI.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
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

        public async Task CompleteOrder(int orderId)
        {
            Order order = _context.Order.Find(orderId);
            order.IsCompleted = true;
            await Update(order);
        }

        public OrderResponse OrderToResponse(Order order)
        {
            return new OrderResponse() { 
                Id = order.Id,
                CardId = order.CardId,
                UserId = order.UserId,
                RequestedValue = order.RequestedValue,
            };
        }

    }
}
