using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MagicShopApi.Contexts;
using MagicShopApi.Models;
using MagicShopApi.Repositories.Interfaces;
using MagicShopApi.Repositories;
using MagicShopApi.Models.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace MagicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(MagicShopContext context, IMemoryCache cache)
        {
            _saleRepository = new SaleRepository(context, cache);
        }

        // GET: api/sales
        [HttpGet]
        public Task<IEnumerable<SaleDTO>> GetSale()
        {
            return _saleRepository.GetSales();
        }

        // GET: api/sales/5
        [HttpGet("{id}")]
        public ActionResult<SaleDTO> GetSale(int id)
        {
            return _saleRepository.GetSaleById(id);
        }

        // PUT: api/sales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, SaleDTO sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            _saleRepository.UpdateSale(sale);

            try
            {
                _saleRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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
        public async Task<ActionResult<SaleDTO>> PostSale(SaleDTO sale)
        {
            _saleRepository.InsertSale(sale);
            _saleRepository.Save();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/sales/5
        [HttpDelete("{id}")]
        public ActionResult<SaleDTO> DeleteSale(int id)
        {
            var sale = _saleRepository.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }

            _saleRepository.DeleteSale(id);
            _saleRepository.Save();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return _saleRepository.Exists(id);
        }
    }
}
