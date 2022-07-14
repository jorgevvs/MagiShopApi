using MagicShop.Common.Entities;

using System.Threading.Tasks;

namespace MagicShop.InventoryItemAPI.Repositories.Interfaces
{
    public interface IInventoryItemRepository : IBaseRepository<InventoryItem>
    {
        Task<bool> Exists(int inventoryItemId);
    }
}
