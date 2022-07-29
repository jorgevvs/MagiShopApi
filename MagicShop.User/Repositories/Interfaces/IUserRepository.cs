using MagicShop.Common.Entities;
using MagicShop.Common.Models.Response;

namespace MagicShop.UserAPI.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Exists(int userId);

        UserResponse UserToResponse(User user);
    }


}
