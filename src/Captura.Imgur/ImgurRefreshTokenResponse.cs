using Newtonsoft.Json;

namespace Captura.Imgur
{
    class ImgurRefreshTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } = default!;

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; } = default!;

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; } = default!;

        [JsonProperty("account_username")]
        public string Username { get; set; } = default!;
    }
}
