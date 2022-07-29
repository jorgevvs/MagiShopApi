using System.Collections.Generic;
using System.Threading.Tasks;
using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using MagicShop.OrderAPI.Repositories.Interfaces;
using MagicShop.OrderAPI.UseCases.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicShop.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository repo)
        {
            _orderRepository = repo;
        }

        // GET: api/sales
        [HttpGet]
        public Task<IEnumerable<Order>> GetOrder()
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
        public async Task<IActionResult> PutOrder(int id, Order order)
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
                if (!await Exists(id))
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
        public async Task<ActionResult<OrderResponse>> CreateNewOrderAsync(
            [FromBody] PostCreateOrderBodyRequest bodyRequest,
            [FromServices] ICreateNewOrderUseCase useCase)
        {
            var response = await useCase.Execute(bodyRequest);
            return response;
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

        [HttpPatch]
        public async Task OrderCompletion(
            [FromBody] PutOrderCompletedBodyRequest bodyRequest,
            [FromServices] IOrderCompletedUseCase useCase)
        {
            await useCase.Execute(bodyRequest);
        }

        private async Task<bool> Exists(int id)
        {
            return _orderRepository.Exists(id);
        }

        [HttpPatch("match")]
        public async Task OrderMatch(
            [FromBody] PutMatchOrderWithSaleBodyRequest bodyRequest,
            [FromServices] IMatchOrderWithSaleUseCase useCase)
        {
            await useCase.Execute(bodyRequest);
        }
    }
}
