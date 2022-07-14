using MagicShop.UserAPI.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.UserAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Save(int id = 0);
        Task Delete(int id);
        Task Update(T obj);
        Task<IEnumerable<T>> GetAll(string cacheId = CacheConstant.allUsersKey);
        Task<T> GetById(int id, string cacheId = CacheConstant.userByIdKey);
        Task Insert(T obj);
    }
}
