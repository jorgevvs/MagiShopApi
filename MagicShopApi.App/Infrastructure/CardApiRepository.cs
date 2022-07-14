using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure
{
    public class CardApiRepository : ICardApiRepository
    {
        private readonly HttpClient _httpclient;

        public CardApiRepository()
        {
            var httpclient = new HttpClient();
            httpclient.BaseAddress = new System.Uri("https://localhost:44356/api/cards/");
            _httpclient = httpclient;
        }
        public async Task DeleteCard(int cardId)
        {
            await _httpclient.DeleteAsync($"{cardId}");
        }

        public async Task<Card> GetCardById(int cardId)
        {
            var result = await _httpclient.GetAsync($"{cardId}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Card>(response);
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Card>>(response);
        }
        public async Task InsertCard(Card card)
        {
            var content = JsonConvert.SerializeObject(card);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PostAsync("", byteContent);
        }
        public async Task UpdateCard(Card card)
        {
            var content = JsonConvert.SerializeObject(card);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpclient.PutAsync($"{card.Id}", byteContent);
        }
    }
}
