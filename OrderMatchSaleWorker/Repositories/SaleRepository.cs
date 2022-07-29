using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using Newtonsoft.Json;
using OrderMatchSaleWorker.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrderMatchSaleWorker.Repositories
{
    internal class SaleRepository : ISaleRepository
    {
        private readonly HttpClient _httpclient;

        public SaleRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            httpclient.BaseAddress = new Uri("https://host.docker.internal:54005/api/sales/");
            _httpclient = httpclient;
        }
        public async Task<IEnumerable<Sale>> GetSales()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Sale>>(response);
        }

        public async Task MatchSale(int itemId, int orderId, int saleId)
        {
            PutMatchOrderWithSaleBodyRequest obj = new PutMatchOrderWithSaleBodyRequest { ItemId = itemId, OrderId = orderId, SaleId = saleId };
            var content = JsonConvert.SerializeObject(obj);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PutAsync($"match", byteContent);

        }
    }
}
