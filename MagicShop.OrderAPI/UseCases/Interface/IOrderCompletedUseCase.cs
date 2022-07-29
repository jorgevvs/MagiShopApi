using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.UseCases.Interface
{
    public interface IOrderCompletedUseCase
    {
        Task Execute(PutOrderCompletedBodyRequest request);
    }
}
