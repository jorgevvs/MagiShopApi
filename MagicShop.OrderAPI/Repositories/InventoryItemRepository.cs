using MagicShop.Common.Entities;
using MagicShop.OrderAPI.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories
{
    public class InventoryItemRepository : IInventoryItemRepository
    {

        private readonly HttpClient _httpClient;
        public InventoryItemRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            _httpClient = httpclient;
        }

        public async Task<InventoryItem> GetInventoryItem(int id)
        {
            var item = await _httpClient.GetAsync($"https://host.docker.internal:54002/api/inventoryitems/{id}");
            return JsonConvert.DeserializeObject<InventoryItem>(await item.Content.ReadAsStringAsync());
        }

        public async Task UpdateInventoryItem(InventoryItem newItem, int newOwnerId)
        {
            newItem.UserId = newOwnerId;
            var content = JsonConvert.SerializeObject(newItem);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await _httpClient.PutAsync($"https://host.docker.internal:54002/api/inventoryitems/{newItem.Id}", byteContent);
        }
    }
}
