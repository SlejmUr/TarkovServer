using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class ServerConfig
    {
        public class Base
        {
            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("port")]
            public int Port { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("discord")]
            public string Discord { get; set; }

            [JsonProperty("website")]
            public string Website { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("debug")]
            public bool Debug { get; set; }

            [JsonProperty("lootDebug")]
            public bool LootDebug { get; set; }

            [JsonProperty("serverIPs")]
            public ServerIPs ServerIPs { get; set; }
        }
        public class ServerIPs
        {
            [JsonProperty("Enable")]
            public bool Enable { get; set; }

            [JsonProperty("Trading")]
            public string Trading { get; set; }

            [JsonProperty("Messaging")]
            public string Messaging { get; set; }

            [JsonProperty("Main")]
            public string Main { get; set; }

            [JsonProperty("RagFair")]
            public string RagFair { get; set; }
        }
    }
}
