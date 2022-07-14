using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure
{
    public class SaleApiRepository : ISaleApiRepository
    {
        private readonly HttpClient _httpclient;

        public SaleApiRepository()
        {
            var httpclient = new HttpClient();
            httpclient.BaseAddress = new System.Uri("https://localhost:44329/api/sales/");
            _httpclient = httpclient;
        }
        public async Task DeleteSale(int saleId)
        {
            await _httpclient.DeleteAsync($"{saleId}");
        }

        public async Task<Sale> GetSaleById(int saleId)
        {
            var result = await _httpclient.GetAsync($"{saleId}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Sale>(response);
        }

        public async Task<IEnumerable<Sale>> GetSales()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Sale>>(response);
        }
        public async Task InsertSale(Sale sale)
        {
            var content = JsonConvert.SerializeObject(sale);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PostAsync("", byteContent);
        }
        public async Task UpdateSale(Sale sale)
        {
            var content = JsonConvert.SerializeObject(sale);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PutAsync($"{sale.Id}", byteContent);
        }
    }
}
