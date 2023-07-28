using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    internal class Response
    {
        public class LoginRSP
        {
            [JsonProperty("token")]
            public string Token { get; set; }

            [JsonProperty("aid")]
            public string Aid { get; set; }

            [JsonProperty("lang")]
            public string Lang { get; set; }

            [JsonProperty("queued")]
            public bool Queued { get; set; }

            [JsonProperty("taxonomy")]
            public string Taxonomy { get; set; }

            [JsonProperty("activeProfileId")]
            public string ActiveProfileId { get; set; }

            [JsonProperty("backend")]
            public Backend Backend { get; set; }

            [JsonProperty("utc_time")]
            public double UtcTime { get; set; }

            [JsonProperty("totalInGame")]
            public long TotalInGame { get; set; }
        }

        public class notif
        {
            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("notifier")]
            public Dictionary<string, string> Notifier { get; set; }

        }
    }
}
