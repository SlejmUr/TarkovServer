using Newtonsoft.Json;

namespace JsonLib.Classes
{
    public class Others
    {
        public class Sizes
        {
            [JsonProperty("SizeUp", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeUp { get; set; }

            [JsonProperty("SizeDown", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeDown { get; set; }

            [JsonProperty("SizeLeft", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeLeft { get; set; }

            [JsonProperty("SizeRight", NullValueHandling = NullValueHandling.Ignore)]
            public int SizeRight { get; set; }

            [JsonProperty("ForcedUp", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedUp { get; set; }

            [JsonProperty("ForcedDown", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedDown { get; set; }

            [JsonProperty("ForcedLeft", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedLeft { get; set; }

            [JsonProperty("ForcedRight", NullValueHandling = NullValueHandling.Ignore)]
            public int ForcedRight { get; set; }
        }

    }
}
