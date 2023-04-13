using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class GameLogout
    {
        public class Response
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string status { get; set; }

        }
    }
}
