using System.Text.Json.Serialization;

namespace MagicShop.Common.Models.Request
{
    public class PostCreateUserBodyRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
    }
}
