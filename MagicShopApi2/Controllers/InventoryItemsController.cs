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
using MagicShopApi.Repositories.Interfaces;
using MagicShopApi.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace MagicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;

        public InventoryItemsController(MagicShopContext context, IMemoryCache cache)
        {
            this._inventoryItemRepository = new InventoryItemRepository(context, cache);
        }

        // GET: api/InventoryItems
        [HttpGet]
        public Task<IEnumerable<InventoryItem>> GetInventoryItem()
        {
            return _inventoryItemRepository.GetInventoryItems();
        }

        //// GET: api/InventoryItems/5
        [HttpGet("{id}")]
        public ActionResult<InventoryItem> GetInventoryItem(int id)
        {
            return _inventoryItemRepository.GetInventoryItemById(id);
        }

        //// PUT: api/InventoryItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryItem(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return BadRequest();
            }

            _inventoryItemRepository.UpdateInventoryItem(inventoryItem);

            try
            {
                _inventoryItemRepository.Save();
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

        //// POST: api/InventoryItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        {
            _inventoryItemRepository.InsertInventoryItem(inventoryItem);
            _inventoryItemRepository.Save();

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        }

        //// DELETE: api/InventoryItems/5
        [HttpDelete("{id}")]
        public ActionResult<InventoryItem> DeleteInventoryItem(int id)
        {
            var inventoryItem = _inventoryItemRepository.GetInventoryItemById(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            _inventoryItemRepository.DeleteInventoryItem(id);
            _inventoryItemRepository.Save();

            return inventoryItem;
        }

        private bool InventoryItemExists(int id)
        {
            return _inventoryItemRepository.Exists(id);
        }
    }
}
