using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.OrderAPI.Repositories.Interfaces;
using MagicShop.OrderAPI.UseCases.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.UseCases
{
    public class OrderCompletedUseCase : IOrderCompletedUseCase
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly HttpClient _httpclient;
        private readonly ILogger _logger;

        public OrderCompletedUseCase(IOrderRepository orderRepository, 
            IInventoryItemRepository inventoryItemRepository, 
            IUserRepository userRepository,
            ILogger<OrderCompletedUseCase> logger)
        {
            _inventoryItemRepository = inventoryItemRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;

            var httpclient = new HttpClient();
            _httpclient = httpclient;

            _logger = logger;

        }
        public async Task Execute(PutOrderCompletedBodyRequest request)
        {
            Order order = await _orderRepository.GetById(request.OrderId);
            User cardOwner = await _userRepository.GetUser(request.CardOwnerId);
            User orderOwner = await _userRepository.GetUser(order.UserId);
            InventoryItem inventoryItem = await _inventoryItemRepository.GetInventoryItem(request.InventoryItemId);

            cardOwner.Balance += order.RequestedValue;
            orderOwner.Balance -= order.RequestedValue;

            await _userRepository.UpdateUser(cardOwner);
            await _userRepository.UpdateUser(orderOwner);
            await _inventoryItemRepository.UpdateInventoryItem(inventoryItem, orderOwner.Id);

            await _orderRepository.CompleteOrder(order.Id);

            _logger.LogInformation($"Order Completed Sucessfuly ID: {order.Id}", DateTimeOffset.Now);
        }
    }
}
