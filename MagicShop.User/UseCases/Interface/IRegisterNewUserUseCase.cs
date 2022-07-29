using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using System.Threading.Tasks;

namespace MagicShop.UserAPI.UseCases.Interface
{
    public interface IRegisterNewUserUseCase
    {
        Task<UserResponse> Execute(PostCreateUserBodyRequest request);
    }
}
