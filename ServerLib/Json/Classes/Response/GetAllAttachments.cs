using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class GetAllAttachments
    {
        public class Response

        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public List<Profile.Message> messages { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public List<object> profiles { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public bool hasMessagesWithRewards { get; set; }

        }

    }
}
