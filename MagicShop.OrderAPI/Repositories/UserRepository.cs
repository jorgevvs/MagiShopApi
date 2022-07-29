using MagicShop.Common.Entities;
using MagicShop.OrderAPI.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.OrderAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        public UserRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            _httpClient = httpclient;
        }
        public async Task<User> GetUser(int userId)
        {
            var user = await _httpClient.GetAsync($"https://host.docker.internal:54006/api/users/{userId}");
            return JsonConvert.DeserializeObject<User>(await user.Content.ReadAsStringAsync());
        }
        public async Task UpdateUser(User user)
        {
            var content = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await _httpClient.PutAsync($"https://host.docker.internal:54006/api/users/{user.Id}", byteContent);
        }
    }
}
