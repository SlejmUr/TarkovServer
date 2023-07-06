using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class CustomConfig
    {
        public class Base
        {
            [JsonProperty("Account")]
            public Account Account { get; set; }

            [JsonProperty("Server")]
            public Server Server { get; set; }
        }
        public class Account
        {
            [JsonProperty("checkTakenNickname")]
            public bool CheckTakenNickname { get; set; }

            [JsonProperty("useSha1")]
            public bool UseSha1 { get; set; }
        }
        
        public class Server
        {
            [JsonProperty("PublicConfigEnabled")]
            public bool PublicConfigEnabled { get; set; }
        }
    }
}
