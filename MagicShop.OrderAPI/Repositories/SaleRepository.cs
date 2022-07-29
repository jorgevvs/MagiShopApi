using MagicShop.Common.Entities;
using MagicShop.OrderAPI.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly HttpClient _httpClient;
        public SaleRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            _httpClient = httpclient;
        }
        public async Task<Sale> GetSale(int saleId)
        {

            var result = await _httpClient.GetAsync($"https://host.docker.internal:54005/api/sales/{saleId}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Sale>(response);
        }
    }
}
