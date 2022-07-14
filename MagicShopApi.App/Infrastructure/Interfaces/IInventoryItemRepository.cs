using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure.Interfaces
{
    public interface IInventoryItemApiRepository
    {
        Task<IEnumerable<InventoryItem>> GetInventoryItems();
        Task<InventoryItem> GetInventoryItemById(int inventoryItemId);
        Task InsertInventoryItem(InventoryItem inventoryItem);
        Task UpdateInventoryItem(InventoryItem inventoryItem);
        Task DeleteInventoryItem(int inventoryItemId);
    }
}
