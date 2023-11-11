using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class CheckVersionResponse
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool isvalid { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string latestVersion { get; set; }
    }
}
