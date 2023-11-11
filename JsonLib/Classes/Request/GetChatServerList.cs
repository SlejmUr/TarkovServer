using Newtonsoft.Json;

namespace JsonLib.Classes.Request
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
