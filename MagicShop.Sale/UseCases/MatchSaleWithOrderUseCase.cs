using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.SaleAPI.Repositories.Interfaces;
using MagicShop.SaleAPI.UseCases.Interface;
using System.Threading.Tasks;

namespace MagicShop.SaleAPI.UseCases
{
    public class MatchSaleWithOrderUseCase : IMatchSaleWithOrderUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ISaleRepository _saleRepository;

        public MatchSaleWithOrderUseCase(IUserRepository userRepository, ISaleRepository saleRepository)
        {
            _userRepository = userRepository;
            _saleRepository = saleRepository;
        }
        public async Task Execute(PutMatchOrderWithSaleBodyRequest bodyRequest)
        {
            Sale sale = await _saleRepository.GetById(bodyRequest.SaleId);
            User user = await _userRepository.GetUser(sale.UserId);
            user.Balance += sale.RequestedValue;
            await _userRepository.UpdateUser(user);

            await _saleRepository.CompleteSale(sale.Id);
        }

    }
}
