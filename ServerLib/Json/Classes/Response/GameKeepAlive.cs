using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class GameKeepAlive
    {
        public class Response
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string msg { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int utc_time { get; set; }

        }
    }
}
