using MagicShop.Common.Entities;
using MagicShop.OrderAPI.Repositories.Interfaces;

namespace MagicShop.SaleAPI.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        bool Exists(int saleId);
    }
}
