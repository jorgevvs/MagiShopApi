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
        private readonly HttpClient _httpclient;

        public InventoryItemRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            httpclient.BaseAddress = new Uri("https://host.docker.internal:54002/api/inventoryitems/");
            _httpclient = httpclient;
        }
        public async Task<InventoryItem> GetInventoryItem(int id)
        {
            var result = await _httpclient.GetAsync($"{id}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<InventoryItem>(response);
        }
    }
}
