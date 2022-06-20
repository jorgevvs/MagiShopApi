using MagicShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicShopApi.Repositories.Interfaces
{
    public interface IInventoryItemRepository : IDisposable
    {
        Task<IEnumerable<InventoryItem>> GetInventoryItems();
        ActionResult<InventoryItem> GetInventoryItemById(int inventoryItemId);
        void InsertInventoryItem(InventoryItem inventoryItem);
        void UpdateInventoryItem(InventoryItem inventoryItem);
        void DeleteInventoryItem(int inventoryItemId);
        void Save();
        bool Exists(int inventoryItemId);
    }
}
