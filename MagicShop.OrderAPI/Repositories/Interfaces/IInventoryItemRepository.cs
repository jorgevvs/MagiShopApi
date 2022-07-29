using MagicShop.Common.Entities;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories.Interfaces
{
    public interface IInventoryItemRepository
    {
        Task<InventoryItem> GetInventoryItem(int id);
        Task UpdateInventoryItem(InventoryItem newItem, int newOwnerId);
    }
}
