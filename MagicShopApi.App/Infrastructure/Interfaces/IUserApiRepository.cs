using MagicShop.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure.Interfaces
{
    public interface IUserApiRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int userId);
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
