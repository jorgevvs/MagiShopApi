using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
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
        public async Task InsertOrder([FromBody] Order order)
        {
            await _ordersRepository.InsertOrder(order);
        }

        [HttpPut]
        public async Task UpdateOrder(Order order)
        {
            await _ordersRepository.UpdateOrder(order);
        }
    }
}
