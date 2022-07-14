using MagicShop.SaleAPI.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.SaleAPI.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Save(int id = 0);
        Task Delete(int id);
        Task Update(T obj);
        Task<IEnumerable<T>> GetAll(string cacheId = CacheConstant.allSalesKey);
        Task<T> GetById(int id, string cacheId = CacheConstant.saleByIdKey);
        Task Insert(T obj);
    }
}
