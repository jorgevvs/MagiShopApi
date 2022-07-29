using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using MagicShop.Common.Models.Request;
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
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            httpclient.BaseAddress = new System.Uri("https://host.docker.internal:54005/api/sales/");
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

        public async Task MatchSale(PutMatchOrderWithSaleBodyRequest bodyRequest)
        {
            var content = JsonConvert.SerializeObject(bodyRequest);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PutAsync($"match", byteContent);
        }
    }
}

