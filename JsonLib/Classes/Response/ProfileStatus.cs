using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class ProfileStatus
    {
        public bool maxPveCountExceeded { get; set; } = false;

        public List<ProfileData> profiles { get; set; }

        public class ProfileData
        {
            public string profileid { get; set; }
            public string? profileToken { get; set; }
            public string status { get; set; }
            public string ip { get; set; }
            public int port { get; set; }
            public string sid { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string version { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string location { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string raidMode { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string mode { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string shortId { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public List<object> additional_info { get; set; }

        }
    }
}
