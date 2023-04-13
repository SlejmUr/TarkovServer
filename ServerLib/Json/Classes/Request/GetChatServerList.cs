using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class GetChatServerList
    {
        public class Request
        {
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
            public string VersionId { get; set; }

        }
    }
}
