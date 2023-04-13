using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class Others
    {
        public class WidthHeight
        {
            [JsonProperty("Width", NullValueHandling = NullValueHandling.Ignore)]
            public long Width { get; set; }

            [JsonProperty("Height", NullValueHandling = NullValueHandling.Ignore)]
            public long Height { get; set; }
        }

        public class Size
        {
            [JsonProperty("SizeUp", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeUp { get; set; }

            [JsonProperty("SizeDown", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeDown { get; set; }

            [JsonProperty("SizeLeft", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeLeft { get; set; }

            [JsonProperty("SizeRight", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeRight { get; set; }
        }

        public class Forced
        {
            [JsonProperty("ForcedUp", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedUp { get; set; }

            [JsonProperty("ForcedDown", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedDown { get; set; }

            [JsonProperty("ForcedLeft", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedLeft { get; set; }

            [JsonProperty("ForcedRight", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedRight { get; set; }
        }

        public class ContainerMap
        {
            [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
            public string Id { get; set; }

            [JsonProperty("map", NullValueHandling = NullValueHandling.Ignore)]
            public Dictionary<string, Map> Map { get; set; }
        }

        public class Map
        {
            [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
            public int Height { get; set; }

            [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
            public int Width { get; set; }

            [JsonProperty("grid", NullValueHandling = NullValueHandling.Ignore)]
            public List<List<string>> Grid { get; set; }
        }

        public class FreeSlot
        {
            [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
            public int X { get; set; }

            [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
            public int Y { get; set; }

            [JsonProperty("r", NullValueHandling = NullValueHandling.Ignore)]
            public int R { get; set; }

            [JsonProperty("slotId", NullValueHandling = NullValueHandling.Ignore)]
            public string SlotId { get; set; }
        }
    }
}
