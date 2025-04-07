using System.Text.Json.Serialization;

namespace API.Model.Dtos.Response
{
    public class TokenResponseDto
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("role")]
        public string[] Roles { get; set; }
    }
}
