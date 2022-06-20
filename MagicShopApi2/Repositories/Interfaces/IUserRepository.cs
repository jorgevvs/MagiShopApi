using MagicShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShopApi.Repositories.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable<User>> GetUsers();
        ActionResult<User> GetUserById(int userId);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        void Save();
        bool Exists(int userId);
        
    }
}
