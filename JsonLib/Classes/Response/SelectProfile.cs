using JsonLib.Classes.Websocket;
using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class SelectProfile
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public NotifierChannel notifier { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string notifierServer { get; set; }
    }
}
