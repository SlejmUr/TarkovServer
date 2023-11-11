using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class GetSuits
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string _id { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> suites { get; set; }
    }
}
