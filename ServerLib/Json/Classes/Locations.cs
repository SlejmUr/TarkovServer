using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class Locations
    {
        public class Base
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Location.Base> locations { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public List<Path> paths { get; set; }

        }
        public class Path
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Source { get; set; }

            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Destination { get; set; }

        }

    }
}
