using Newtonsoft.Json;

namespace ServerLib.Json
{
    public class Customization
    {
        public class Base
        {
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("_name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("_parent", NullValueHandling = NullValueHandling.Ignore)]
            public string Parent { get; set; }

            [JsonProperty("_type", NullValueHandling = NullValueHandling.Ignore)]
            public string Type { get; set; }

            [JsonProperty("_props", NullValueHandling = NullValueHandling.Ignore)]
            public Props Props { get; set; }

            [JsonProperty("_proto", NullValueHandling = NullValueHandling.Ignore)]
            public string? Proto { get; set; }
        }
        public class Props
        {
            [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
            public string? Name { get; set; }

            [JsonProperty("ShortName", NullValueHandling = NullValueHandling.Ignore)]
            public string? ShortName { get; set; }

            [JsonProperty("Description", NullValueHandling = NullValueHandling.Ignore)]
            public string? Description { get; set; }

            [JsonProperty("Side", NullValueHandling = NullValueHandling.Ignore)]
            public List<string>? Side { get; set; }

            [JsonProperty("BodyPart", NullValueHandling = NullValueHandling.Ignore)]
            public string? BodyPart { get; set; }

            [JsonProperty("WatchPrefab", NullValueHandling = NullValueHandling.Ignore)]
            public Fab? WatchPrefab { get; set; }

            [JsonProperty("IntegratedArmorVest", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IntegratedArmorVest { get; set; }

            [JsonProperty("WatchPosition", NullValueHandling = NullValueHandling.Ignore)]
            public WatchTion? WatchPosition { get; set; }

            [JsonProperty("WatchRotation", NullValueHandling = NullValueHandling.Ignore)]
            public WatchTion? WatchRotation { get; set; }

            [JsonProperty("AvailableAsDefault", NullValueHandling= NullValueHandling.Ignore)]
            public bool? AvailableAsDefault { get; set; }

            [JsonProperty("Body", NullValueHandling = NullValueHandling.Ignore)]
            public string? Body { get; set; }

            [JsonProperty("Hands", NullValueHandling = NullValueHandling.Ignore)]
            public string? Hands { get; set; }

            [JsonProperty("Feet", NullValueHandling = NullValueHandling.Ignore)]
            public string? Feet { get; set; }
        }
        public class Fab
        {
            [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
            public string Path { get; set; }

            [JsonProperty("rcid", NullValueHandling = NullValueHandling.Ignore)]
            public string Rcid { get; set; }
        }

        public class WatchTion
        {
            [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
            public double X { get; set; }

            [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
            public double Y { get; set; }

            [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
            public double Z { get; set; }
        }
    }
}
