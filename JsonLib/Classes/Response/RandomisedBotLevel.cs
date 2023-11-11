using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class RandomisedBotLevel
    {
        public class Result
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int level { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public int exp { get; set; }

        }

    }
}
