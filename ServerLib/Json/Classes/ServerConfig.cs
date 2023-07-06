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

            [JsonProperty("version")]
            public string Version { get; set; }

            [JsonProperty("debug")]     //  Can be used same as argument
            public bool Debug { get; set; }

            [JsonProperty("servers")]   //   Multiplayer server IPS
            public List<IPPort> Servers { get; set; }

            public class IPPort
            {
                [JsonProperty("ip")]
                public string Ip { get; set; }
                [JsonProperty("port")]
                public int Port { get; set; }
            
            }
        }
    }
}
