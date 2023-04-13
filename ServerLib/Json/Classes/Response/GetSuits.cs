using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class GetSuits
    {
        public class Response
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string _id { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public List<string> suites { get; set; }
        }
    }
}
