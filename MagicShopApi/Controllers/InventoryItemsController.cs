using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MagicShopApi.Contexts;
using MagicShopApi.Models;
using MagicShopApi.Models.DTO;

namespace MagicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly MagicShopContext _context;

        public InventoryItemsController(MagicShopContext context)
        {
            _context = context;
        }

        // GET: api/InventoryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> GetInventoryItem()
        {
            return await _context.InventoryItem.Select(x => InventoryItemToDTO(x)).ToListAsync();
        }

        // GET: api/InventoryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItemDTO>> GetInventoryItem(int id)
        {
            var inventoryItem = await _context.InventoryItem.FindAsync(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return InventoryItemToDTO(inventoryItem);
        }
        // GET: api/InventoryItems/user/5
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<InventoryItemDTO>>> GetUserInventoryItem(int id)
        {
            return await _context.InventoryItem.Where(x => x.UserId == id).Select(x => InventoryItemToDTO(x)).ToListAsync();
        }



        // PUT: api/InventoryItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemExists(id))
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

        // POST: api/InventoryItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InventoryItemDTO>> PostInventoryItem(InventoryItemDTO inventoryItemDTO)
        {
            var inventoryItem = new InventoryItem
            {
                UserId = inventoryItemDTO.UserId,
                CardId = inventoryItemDTO.CardId
            };

            _context.InventoryItem.Add(inventoryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, InventoryItemToDTO(inventoryItem));
        }

        // DELETE: api/InventoryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryItem>> DeleteInventoryItem(int id)
        {
            var inventoryItem = await _context.InventoryItem.FindAsync(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.InventoryItem.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return inventoryItem;
        }

        private bool InventoryItemExists(int id)
        {
            return _context.InventoryItem.Any(e => e.Id == id);
        }
        private static InventoryItemDTO InventoryItemToDTO(InventoryItem item) =>
           new InventoryItemDTO
           {
               Id = item.Id,
               CardId = item.CardId,
               UserId = item.UserId
           };
    }
}
