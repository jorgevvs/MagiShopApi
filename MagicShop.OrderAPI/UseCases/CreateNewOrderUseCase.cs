using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using MagicShop.OrderAPI.Repositories.Interfaces;
using MagicShop.OrderAPI.UseCases.Interface;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.UseCases
{
    public class CreateNewOrderUseCase : ICreateNewOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateNewOrderUseCase> _logger;

        public CreateNewOrderUseCase(IOrderRepository repo, ILogger<CreateNewOrderUseCase> logger)
        {
            _orderRepository = repo;
            _logger = logger;
        }
        public async Task<OrderResponse> Execute(PostCreateOrderBodyRequest request)
        {
            var orderFromBody = new Order() {
                CardId = request.CardId,
                RequestedValue = request.RequestedValue,
                UserId = request.UserId
            };
            await _orderRepository.Insert(orderFromBody);
            await _orderRepository.Save();

            _logger.LogInformation($"Order created sucessfully ID: {orderFromBody.Id}");
            return _orderRepository.OrderToResponse(orderFromBody);
        }
    }
}
