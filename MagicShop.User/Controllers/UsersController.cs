using System.Collections.Generic;
using System.Threading.Tasks;
using MagicShop.UserAPI.Repositories;
using MagicShop.UserAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MagicShop.Common.Entities;
using Microsoft.EntityFrameworkCore;
using MagicShop.UserAPI.Contexts;

namespace MagicShop.UserAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(UserContext context, IMemoryCache cache)
        {
            _userRepository = new UserRepository(context, cache);
        }

        // GET: api/users
        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _userRepository.GetAll();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetById(id);
        }

        // PUT: api/users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.Update(user);

            try
            {
                await _userRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id).Result)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userRepository.Insert(user);
            await _userRepository.Save();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.Delete(id);
            await _userRepository.Save();

            return NoContent();
        }

        private async Task<bool> Exists(int id)
        {
            return _userRepository.Exists(id);
        }
    }
}
