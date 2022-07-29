using MagicShop.Common.Models.Request;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.UseCases.Interface
{
    public interface IMatchOrderWithSaleUseCase
    {
        Task Execute(PutMatchOrderWithSaleBodyRequest request);
    }
}
