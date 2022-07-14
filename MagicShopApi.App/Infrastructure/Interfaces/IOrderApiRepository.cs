using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure.Interfaces
{
    public interface IOrderApiRepository
    {
            Task<IEnumerable<Order>> GetOrders();
            Task<Order> GetOrderById(int orderId);
            Task InsertOrder(Order order);
            Task UpdateOrder(Order order);
            Task DeleteOrder(int orderId);
    }
}



