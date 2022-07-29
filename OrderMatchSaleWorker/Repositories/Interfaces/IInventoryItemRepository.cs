using MagicShop.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker.Repositories.Interfaces
{
    public interface IInventoryItemRepository
    {
        Task<InventoryItem> GetInventoryItem(int id);

    }
}
