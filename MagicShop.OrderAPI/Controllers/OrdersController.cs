using System.Collections.Generic;
using System.Threading.Tasks;
using MagicShop.Common.Entities;
using MagicShop.OrderAPI.Contexts;
using MagicShop.OrderAPI.Repositories;
using MagicShop.SaleAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Caching.Memory;

namespace MagicShop.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(OrderContext context, IMemoryCache cache)
        {
            _orderRepository = new OrderRepository(context, cache);
        }

        // GET: api/sales
        [HttpGet]
        public Task<IEnumerable<Order>> GetSale()
        {
            return _orderRepository.GetAll();
        }

        // GET: api/sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetSale(int id)
        {
            return await _orderRepository.GetById(id);
        }

        // PUT: api/sales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            await _orderRepository.Update(order);

            try
            {
                await _orderRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id).Result)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/sales
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostSale(Order order)
        {
            await _orderRepository.Insert(order);
            await _orderRepository.Save();

            return CreatedAtAction("GetSale", new { id = order.Id }, order);
        }

        // DELETE: api/sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(int id)
        {
            var sale = _orderRepository.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }

            await _orderRepository.Delete(id);
            await _orderRepository.Save();

            return NoContent();
        }

        private async Task<bool> Exists(int id)
        {
            return _orderRepository.Exists(id);
        }
    }
}
