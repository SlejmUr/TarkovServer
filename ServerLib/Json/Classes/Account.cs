using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class Account
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("aid")]
        public string Aid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public EPerms Permission { get; set; }
    }
}
