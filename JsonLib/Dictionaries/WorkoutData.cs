using Newtonsoft.Json;

namespace JsonLib.Dictionaries
{
    public class WorkoutData : Dictionary<string, object>
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public object skills { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public object effects { get; set; }
    }
}
