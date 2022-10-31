using MagicShop.Common.Entities;
using Newtonsoft.Json;
using OrderMatchSaleWorker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker.Repositories
{
    internal class InventoryItemRepository : IInventoryItemRepository
    {
        private readonly String INVENTORY_ITEMS_API_URI = "https://host.docker.internal:54004/api/inventoryitems";
    
        private readonly HttpClient _httpclient;

        public InventoryItemRepository() {
            _httpclient = getHttpClient(INVENTORY_ITEMS_API_URI);
        }
        
        public async Task<InventoryItem> GetInventoryItem(int id)
        {
            var result = await _httpclient.GetAsync($"{id}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<InventoryItem>(response);
        }
        
        private HttpClient getHttpClient(String uri) {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            httpclient.BaseAddress = new Uri(uri);
            return httpclient;
        }
    }
}
