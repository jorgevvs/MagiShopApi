using MagicShop.InventoryItemAPI.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.InventoryItemAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Save(int id = 0);
        Task Delete(int id);
        Task Update(T obj);
        Task<IEnumerable<T>> GetAll(string cacheId = CacheConstant.allInventoryItemsKey);
        Task<T> GetById(int id, string cacheId = CacheConstant.inventoryItemByIdKey);
        Task Insert(T obj);
    }
}
