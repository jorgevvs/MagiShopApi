using MagicShop.UserAPI.Models.Response;
using System.Threading.Tasks;

namespace MagicShop.UserAPI.UseCases.Interface
{
    public interface IRegisterNewUserUseCase
    {
        Task<UserResponse> Execute();
    }
}
