using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserApiRepository _usersRepository;

        public UserApiController(IUserApiRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        [HttpDelete("{userId}")]
        public void DeleteUser(int userId)
        {
            _usersRepository.DeleteUser(userId);
        }
        [HttpGet("{userId}")]
        public async Task<User> GetUserById([FromRoute] int userId)
        {
            return await _usersRepository.GetUserById(userId);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _usersRepository.GetUsers();
        }
        [HttpPost]
        public void InsertUser([FromBody] User user)
        {
            _usersRepository.InsertUser(user);
        }

        [HttpPut]
        public void UpdateUser(User user)
        {
            _usersRepository.UpdateUser(user);
        }
    }
}
