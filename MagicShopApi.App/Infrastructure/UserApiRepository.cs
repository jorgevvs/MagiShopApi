using MagicShop.API.Infrastructure.Interfaces;
using MagicShop.Common.Entities;
using MagicShop.Common.Models.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MagicShop.API.Infrastructure
{
    public class UserApiRepository : IUserApiRepository
    {
        private readonly HttpClient _httpclient;

        public UserApiRepository()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var httpclient = new HttpClient(clientHandler);
            httpclient.BaseAddress = new System.Uri("https://host.docker.internal:54006/api/users/");
            _httpclient = httpclient;
        }
        public async Task DeleteUser(int userId)
        {
            await _httpclient.DeleteAsync($"{userId}");
        }
        public async Task<User> GetUserById(int userId)
        {
            var result = await _httpclient.GetAsync($"{userId}");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(response);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _httpclient.GetAsync("");
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<User>>(response);
        }
        public async Task<UserResponse> InsertUser(User user)
        {
            var content = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = (await _httpclient.PostAsync("", byteContent));
            return JsonConvert.DeserializeObject<UserResponse>(await result.Content.ReadAsStringAsync());
        }
        public async Task UpdateUser(User user)
        {
            var content = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await _httpclient.PutAsync($"{user.Id}", byteContent);
        }
    }
}
