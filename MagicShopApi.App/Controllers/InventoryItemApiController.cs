using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemApiController : ControllerBase
    {
        private readonly IInventoryItemApiRepository _inventoryItemsRepository;

        public InventoryItemApiController(IInventoryItemApiRepository inventoryItemsRepository)
        {
            _inventoryItemsRepository = inventoryItemsRepository;
        }
        [HttpDelete("{inventoryItemId}")]
        public void DeleteInventoryItem(int inventoryItemId)
        {
            _inventoryItemsRepository.DeleteInventoryItem(inventoryItemId);
        }
        [HttpGet("{inventoryItemId}")]
        public async Task<InventoryItem> GetInventoryItemById([FromRoute] int inventoryItemId)
        {
            return await _inventoryItemsRepository.GetInventoryItemById(inventoryItemId);
        }

        [HttpGet]
        public async Task<IEnumerable<InventoryItem>> GetInventoryItems()
        {
            return await _inventoryItemsRepository.GetInventoryItems();
        }
        [HttpPost]
        public void InsertInventoryItem([FromBody] InventoryItem inventoryItem)
        {
            _inventoryItemsRepository.InsertInventoryItem(inventoryItem);
        }

        [HttpPut]
        public void UpdateInventoryItem(InventoryItem inventoryItem)
        {
            _inventoryItemsRepository.UpdateInventoryItem(inventoryItem);
        }
    }
}
