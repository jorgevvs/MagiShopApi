using MagicShop.Common.Entities;
using MagicShop.Common.Models.Response;
using MagicShop.OrderAPI.Repositories.Interfaces;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        bool Exists(int saleId);
        OrderResponse OrderToResponse(Order order);
        Task CompleteOrder(int orderId);
    }
}
