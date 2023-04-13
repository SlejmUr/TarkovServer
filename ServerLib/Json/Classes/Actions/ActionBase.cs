using Newtonsoft.Json;

namespace ServerLib.Json.Classes.Actions
{
    #region ActionBase
    public class ActionBase
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Action { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int timestamp { get; set; }
    }
    #endregion
}
