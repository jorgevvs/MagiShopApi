using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
using MagicShop.Common.Models.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure
{
    public class OrderApiRepository : IOrderApiRepository
    {
        private readonly HttpClient _httpclient;

        public OrderApiRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            httpclient.BaseAddress = new System.Uri("https://host.docker.internal:54004/api/orders/");
            _httpclient = httpclient;
        }
        public async Task DeleteOrder(int orderId)
        {
            await _httpclient.DeleteAsync($"{orderId}");
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            var result = await _httpclient.GetAsync($"{orderId}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Order>(response);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Order>>(response);
        }
        public async Task<OrderResponse> InsertOrder(Order order)
        {
            var content = JsonConvert.SerializeObject(order);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PostAsync("", byteContent);
            return JsonConvert.DeserializeObject<OrderResponse>(await result.Content.ReadAsStringAsync());
        }
        public async Task UpdateOrder(Order order)
        {
            var content = JsonConvert.SerializeObject(order);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PutAsync($"{order.Id}", byteContent);
        }

        public async Task CompleteOrder(PutOrderCompletedBodyRequest bodyRequest)
        {
            var content = JsonConvert.SerializeObject(bodyRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PatchAsync($"", byteContent);
        }

        public async Task OrderMatch(PutMatchOrderWithSaleBodyRequest bodyRequest)
        {
            var content = JsonConvert.SerializeObject(bodyRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PatchAsync($"match", byteContent);
        }
    }
}
