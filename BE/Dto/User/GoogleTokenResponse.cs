using Newtonsoft.Json;

namespace BE.Dto.User
{
    public class GoogleTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}