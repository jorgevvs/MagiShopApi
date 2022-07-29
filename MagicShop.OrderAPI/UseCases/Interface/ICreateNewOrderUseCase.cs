using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.UseCases.Interface
{
    public interface ICreateNewOrderUseCase
    {
        Task<OrderResponse> Execute(PostCreateOrderBodyRequest request);
    }
}
