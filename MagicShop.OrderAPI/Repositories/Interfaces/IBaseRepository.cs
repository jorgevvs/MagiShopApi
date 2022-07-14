using MagicShop.OrderAPI.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Save(int id = 0);
        Task Delete(int id);
        Task Update(T obj);
        Task<IEnumerable<T>> GetAll(string cacheId = CacheConstant.allOrdersKey);
        Task<T> GetById(int id, string cacheId = CacheConstant.orderByIdKey);
        Task Insert(T obj);
    }
}
