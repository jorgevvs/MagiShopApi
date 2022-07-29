using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MagicShop.InventoryItemAPI.Repositories.Interfaces;
using MagicShopApi.InventoryItemAPI.Repositories;
using MagicShop.Common.Entities;
using MagicShop.InventoryItemAPI.Contexts;
using MagicShop.InventoryItemAPI.UseCases.Interface;

namespace MagicShop.InventoryItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemsController : ControllerBase
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;

        public InventoryItemsController(IInventoryItemRepository inventoryItemRepository, InventoryItemContext context, IMemoryCache cache)
        {
            _inventoryItemRepository = inventoryItemRepository;
        }

        // GET: api/InventoryItems
        [HttpGet]
        public Task<IEnumerable<InventoryItem>> GetInventoryItem()
        {
            return _inventoryItemRepository.GetAll();
        }

        //// GET: api/InventoryItems/5
        [HttpGet("{id}")]
        public Task<InventoryItem> GetInventoryItem(int id)
        {
            return _inventoryItemRepository.GetById(id);
        }
        
        //// GET: api/InventoryItems/5
        [HttpGet("user/{id}")]
        public Task<IList<InventoryItem>> GetInventoryItemsFromUser(
            [FromRoute] int id,
            [FromServices] IReturnAllUserCardsUseCase useCase
            )
        {
            return useCase.Execute(id);
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

            await _inventoryItemRepository.Update(inventoryItem);

            try
            {
                await _inventoryItemRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await InventoryItemExists(id))
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
            await _inventoryItemRepository.Insert(inventoryItem);
            await _inventoryItemRepository.Save();

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        }


        //// DELETE: api/InventoryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryItem>> DeleteInventoryItem(int id)
        {
            var inventoryItem = await _inventoryItemRepository.GetById(id);
            if (inventoryItem == null)
            {
                return NotFound();
            }

            await _inventoryItemRepository.Delete(id);
            await _inventoryItemRepository.Save();

            return inventoryItem;
        }

        private Task<bool> InventoryItemExists(int id)
        {
            return _inventoryItemRepository.Exists(id);
        }
    }
}
