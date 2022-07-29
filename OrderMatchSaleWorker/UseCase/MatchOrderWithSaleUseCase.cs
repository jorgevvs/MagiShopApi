
using MagicShop.Common.Entities;
using OrderMatchSaleWorker.Repositories.Interfaces;
using OrderMatchSaleWorker.UseCase.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker.UseCase
{
    public class MatchOrderWithSaleUseCase : IMatchOrderWithSaleUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IInventoryItemRepository _inventoryItemRepository;

        public MatchOrderWithSaleUseCase(IOrderRepository orderRepo, ISaleRepository saleRepo, IInventoryItemRepository inventoryItemRepository)
        {
            _orderRepository = orderRepo;
            _saleRepository = saleRepo;
            _inventoryItemRepository = inventoryItemRepository;
        }

        public async Task Execute()
        {
            IEnumerable<Order> orders = await _orderRepository.GetOrders();
            foreach (Order order in orders)
            {
                Sale match = await GetMatch(order);
                if (match.Id != 0)
                {
                    await _orderRepository.MatchOrder(match.Id, match.InventoryItemId, order.Id);
                    await _saleRepository.MatchSale(match.Id, match.InventoryItemId, order.Id);
                }
            }
        }


        private async Task<Sale> GetMatch(Order order)
        {
            Sale saleMatch = new Sale() { RequestedValue = 9999999 }; 

            foreach (Sale sale in await _saleRepository.GetSales())
            {
                var item = await _inventoryItemRepository.GetInventoryItem(sale.InventoryItemId);
                if (item.CardId == order.CardId && 
                    sale.RequestedValue <= order.RequestedValue && 
                    sale.RequestedValue < saleMatch.RequestedValue &&
                    sale.IsCompleted == false) 
                    saleMatch = sale;
            }
            return saleMatch;
        }


    }
}
