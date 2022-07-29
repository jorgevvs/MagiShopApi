using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure
{
    public class OfferApiRepository : IOfferApiRepository
    {
        private readonly HttpClient _httpclient;

        public OfferApiRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            httpclient.BaseAddress = new System.Uri("https://host.docker.internal:54003/api/offers/");
            _httpclient = httpclient;
        }
        public async Task DeleteOffer(int offerId)
        {
            await _httpclient.DeleteAsync($"{offerId}");
        }

        public async Task<Offer> GetOfferById(int offerId)
        {
            var result = await _httpclient.GetAsync($"{offerId}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Offer>(response);
        }

        public async Task<IEnumerable<Offer>> GetOffers()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Offer>>(response);
        }
        public async Task InsertOffer(Offer offer)
        {
            var content = JsonConvert.SerializeObject(offer);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PostAsync("", byteContent);
        }
        public async Task UpdateOffer(Offer offer)
        {
            var content = JsonConvert.SerializeObject(offer);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PutAsync($"{offer.Id}", byteContent);
        }
    }
}
