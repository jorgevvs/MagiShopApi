using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.OrderAPI.Repositories.Interfaces;
using MagicShop.OrderAPI.UseCases.Interface;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.UseCases
{
    public class MatchOrderWithSaleUseCase : IMatchOrderWithSaleUseCase
    {

        private readonly IInventoryItemRepository _inventoryItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<MatchOrderWithSaleUseCase> _logger;

        public MatchOrderWithSaleUseCase(IOrderRepository orderRepository, 
            IUserRepository userRepository, 
            IInventoryItemRepository inventoryItemRepository,
            ISaleRepository saleRepository,
            ILogger<MatchOrderWithSaleUseCase> logger)
        {
            _inventoryItemRepository = inventoryItemRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _saleRepository = saleRepository;
            _logger = logger;
        }

        public async Task Execute(PutMatchOrderWithSaleBodyRequest request)
        {
            await _orderRepository.CompleteOrder(request.OrderId);
            Order order = await _orderRepository.GetById(request.OrderId);
            User orderOwner = await _userRepository.GetUser(order.UserId);


            InventoryItem item = await _inventoryItemRepository.GetInventoryItem(request.ItemId);
            await _inventoryItemRepository.UpdateInventoryItem(item, orderOwner.Id);


            var sale = await _saleRepository.GetSale(request.SaleId);
            orderOwner.Balance -= sale.RequestedValue;

            await _userRepository.UpdateUser(orderOwner);

            await _orderRepository.CompleteOrder(order.Id);

            _logger.LogInformation($"");
        }
    }
}
