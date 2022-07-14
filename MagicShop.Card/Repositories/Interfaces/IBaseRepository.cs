using MagicShop.CardAPI.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.CardAPI.Repositories.Interfaces
{
    public interface IBaseRepository <T>
    {
        Task Save(int id = 0);
        Task Delete(int id);
        Task Update(T obj);
        Task<IEnumerable<T>> GetAll(string cacheId = CacheConstant.allCardKey);
        Task<T> GetById(int id, string cacheId = CacheConstant.cardByIdKey);
        Task Insert(T obj);
    }
}
