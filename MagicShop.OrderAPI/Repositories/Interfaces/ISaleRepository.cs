using MagicShop.Common.Entities;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<Sale> GetSale(int saleId);
    }
}
