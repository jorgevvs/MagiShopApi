using MagicShop.Common.Entities;
using System.Threading.Tasks;

namespace MagicShop.SaleAPI.Repositories.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        bool Exists(int saleId);
        Task CompleteSale(int saleId);
    }
}
