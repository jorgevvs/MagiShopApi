using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure.Interfaces
{
    public interface ISaleApiRepository
    {
        Task<IEnumerable<Sale>> GetSales();
        Task<Sale> GetSaleById(int saleId);
        Task InsertSale(Sale sale);
        Task UpdateSale(Sale sale);
        Task DeleteSale(int saleId);
        Task MatchSale(PutMatchOrderWithSaleBodyRequest bodyRequest);
    }
}
