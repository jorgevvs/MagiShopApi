using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure
{
    public class InventoryItemApiRepository : IInventoryItemApiRepository
    {
        private readonly HttpClient _httpclient;

        public InventoryItemApiRepository()
        {
            var httpclient = new HttpClient();
            httpclient.BaseAddress = new System.Uri("https://localhost:44360/api/inventoryitems/");
            _httpclient = httpclient;
        }
        public async Task DeleteInventoryItem(int inventoryItemId)
        {
            await _httpclient.DeleteAsync($"{inventoryItemId}");
        }

        public async Task<InventoryItem> GetInventoryItemById(int inventoryItemId)
        {
            var result = await _httpclient.GetAsync($"{inventoryItemId}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<InventoryItem>(response);
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoryItems()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<InventoryItem>>(response);
        }
        public async Task InsertInventoryItem(InventoryItem inventoryItem)
        {
            var content = JsonConvert.SerializeObject(inventoryItem);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PostAsync("", byteContent);
        }
        public async Task UpdateInventoryItem(InventoryItem inventoryItem)
        {
            var content = JsonConvert.SerializeObject(inventoryItem);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PutAsync($"{inventoryItem.Id}", byteContent);
        }
    }
}
