using Newtonsoft.Json;

namespace BE.Dto.User
{
    public class GoogleUserInfo
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}