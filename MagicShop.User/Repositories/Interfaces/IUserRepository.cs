using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagicShop.Common.Entities;

namespace MagicShop.UserAPI.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool Exists(int userId);
    }
}
