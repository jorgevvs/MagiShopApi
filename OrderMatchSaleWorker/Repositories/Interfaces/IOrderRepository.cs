using MagicShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task MatchOrder(int cardOwnerId, int itemId, int orderId);
    }
}
