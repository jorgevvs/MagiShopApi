using MagicShop.Common.Models.Request;
using System.Threading.Tasks;

namespace MagicShop.SaleAPI.UseCases.Interface
{
    public interface IMatchSaleWithOrderUseCase
    {
        Task Execute(PutMatchOrderWithSaleBodyRequest bodyRequest);
    }
}
