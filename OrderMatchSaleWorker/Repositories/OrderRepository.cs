using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using Microsoft.Extensions.Logging;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly String ORDERS_API_URI = "https://host.docker.internal:54004/api/orders";
        
        private readonly HttpClient _httpclient;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ILogger<OrderRepository> logger) {
            _httpclient = getHttpClient(ORDERS_API_URI);
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(response);
        }

        public async Task MatchOrder(int saleId, int orderId, int itemId)
        {
            PutMatchOrderWithSaleBodyRequest obj = new PutMatchOrderWithSaleBodyRequest { ItemId = itemId, OrderId = orderId, SaleId = saleId };
            var content = JsonConvert.SerializeObject(obj);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PatchAsync($"match", byteContent);
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



