using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure.Interfaces
{
    public interface IOrderApiRepository
    {
            Task<IEnumerable<Order>> GetOrders();
            Task<Order> GetOrderById(int orderId);
            Task<OrderResponse> InsertOrder(Order order);
            Task UpdateOrder(Order order);
            Task DeleteOrder(int orderId);
            Task OrderMatch(PutMatchOrderWithSaleBodyRequest bodyRequest);
            Task CompleteOrder(PutOrderCompletedBodyRequest bodyRequest);
    }
}



