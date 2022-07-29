using MagicShop.Common.Entities;
using MagicShop.InventoryItemAPI.Repositories.Interfaces;
using MagicShop.InventoryItemAPI.UseCases.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShop.InventoryItemAPI.UseCases
{
    public class ReturnAllUserCardsUseCase : IReturnAllUserCardsUseCase
    {
        private readonly IInventoryItemRepository _inventoryItemRepository;
        public ReturnAllUserCardsUseCase(IInventoryItemRepository inventoryItemRepository)
        {
            _inventoryItemRepository = inventoryItemRepository;
        }

        public async Task<IList<InventoryItem>> Execute(int userId)
        {
            IList<InventoryItem> items = new List<InventoryItem>();
            foreach(InventoryItem item in await _inventoryItemRepository.GetAll())
            {
                if(item.UserId == userId)
                {
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
