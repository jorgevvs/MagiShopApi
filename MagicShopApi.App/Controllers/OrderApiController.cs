using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderApiRepository _ordersRepository;

        public OrderApiController(IOrderApiRepository salesRepository)
        {
            _ordersRepository = salesRepository;
        }
        [HttpDelete("{saleId}")]
        public async Task DeleteOrder(int saleId)
        {
            await _ordersRepository.DeleteOrder(saleId);
        }
        [HttpGet("{saleId}")]
        public async Task<Order> GetOrderById([FromRoute] int saleId)
        {
            return await _ordersRepository.GetOrderById(saleId);
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _ordersRepository.GetOrders();
        }
        [HttpPost]
        public async Task<OrderResponse> InsertOrder([FromBody] Order order)
        {
            return await _ordersRepository.InsertOrder(order);
        }

        [HttpPut]
        public async Task UpdateOrder(Order order)
        {
            await _ordersRepository.UpdateOrder(order);
        }

        [HttpPatch]
        public async Task CompleteOrder(
            [FromBody] PutOrderCompletedBodyRequest bodyRequest)
        {
            await _ordersRepository.CompleteOrder(bodyRequest);
        }

        [HttpPatch("match")]
        public async Task MatchOrder( [FromBody] PutMatchOrderWithSaleBodyRequest bodyRequest)
        {
            await _ordersRepository.OrderMatch(bodyRequest);
        }
    }
}
