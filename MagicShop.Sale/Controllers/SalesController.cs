using System.Collections.Generic;
using System.Threading.Tasks;
using MagicShop.Common.Entities;
using MagicShop.SaleAPI.Contexts;
using MagicShop.SaleAPI.Repositories;
using MagicShop.SaleAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Caching.Memory;

namespace MagicShop.SaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(SaleContext context, IMemoryCache cache)
        {
            _saleRepository = new SaleRepository(context, cache);
        }

        // GET: api/sales
        [HttpGet]
        public Task<IEnumerable<Sale>> GetSale()
        {
            return _saleRepository.GetAll();
        }

        // GET: api/sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(int id)
        {
            return await _saleRepository.GetById(id);
        }

        // PUT: api/sales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            await _saleRepository.Update(sale);

            try
            {
                await _saleRepository.Save();
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
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            await _saleRepository.Insert(sale);
            await _saleRepository.Save();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> Delete(int id)
        {
            var sale = _saleRepository.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }

            await _saleRepository.Delete(id);
            await _saleRepository.Save();

            return NoContent();
        }

        private async Task<bool> Exists(int id)
        {
            return  _saleRepository.Exists(id);
        }
    }
}
