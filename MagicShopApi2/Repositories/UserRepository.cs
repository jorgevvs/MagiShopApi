using MagicShopApi.Contexts;
using MagicShopApi.Models;
using MagicShopApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicShopApi.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly MagicShopContext _context;
        private readonly IMemoryCache _cache;

        public UserRepository(MagicShopContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public void DeleteUser(int userId)
        {
            User user = _context.User.Find(userId);
            _context.User.Remove(user);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool Exists(int userId)
        {
            return _context.User.Any(x => x.Id == userId);
        }

        public ActionResult<User> GetUserById(int userId)
        {
            var user = _cache.GetOrCreate("Users_GetById_" + userId, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.User.Find(userId);
            });
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = _cache.GetOrCreate("Users_GetAll", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(30);
                entry.SetPriority(CacheItemPriority.Low);
                System.Threading.Thread.Sleep(1000);
                return _context.User.ToListAsync();
            });
            return await users;
        }

        public void InsertUser(User user)
        {
            _context.User.Add(user);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
