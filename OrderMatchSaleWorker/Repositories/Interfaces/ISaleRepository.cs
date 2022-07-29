using MagicShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetSales();
        Task MatchSale(int itemId, int orderId, int saleId);
    }
}
