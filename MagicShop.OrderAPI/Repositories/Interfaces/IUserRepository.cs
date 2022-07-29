using MagicShop.Common.Entities;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task UpdateUser(User user);
    }
}
