using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using MagicShop.Common.Entities;
using MagicShop.UserAPI.Repositories.Interfaces;
using MagicShop.UserAPI.Contexts;
using MagicShop.Common.Models.Response;

namespace MagicShop.UserAPI.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(UserContext context, IMemoryCache cache): base(context, cache)
        {
        }

        public bool Exists(int userId)
        {
            return _context.User.Any(x => x.Id == userId);
        }

        public UserResponse UserToResponse(User user)
        {
            return new UserResponse() { Name = user.Name, Id= user.Id };
        }
    }
}
