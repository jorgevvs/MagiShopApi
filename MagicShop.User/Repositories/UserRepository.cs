using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicShop.Common.Entities;
using MagicShop.UserAPI.Repositories.Interfaces;
using MagicShop.UserAPI.Contexts;

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

        
    }
}
