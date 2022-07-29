using MagicShop.Common.Entities;
using System.Threading.Tasks;

namespace MagicShop.SaleAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task UpdateUser(User user);
    }
}
