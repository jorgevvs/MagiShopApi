using MagicShop.Common.Entities;


namespace MagicShop.SaleAPI.Repositories.Interfaces
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        bool Exists(int saleId);
    }
}
