using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using MagicShop.UserAPI.Repositories.Interfaces;
using MagicShop.UserAPI.UseCases.Interface;
using System.Threading.Tasks;

namespace MagicShop.UserAPI.UseCases
{
    public class RegisterNewUserUseCase : IRegisterNewUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterNewUserUseCase(IUserRepository repo)
        {
            _userRepository = repo;
        }

        public async Task<UserResponse> Execute(PostCreateUserBodyRequest request)
        {
            var userFromBody = new User() { Balance = request.Balance, Name = request.Name };
            await _userRepository.Insert(userFromBody);
            await _userRepository.Save();
            return _userRepository.UserToResponse(userFromBody);
        }
    }
}
