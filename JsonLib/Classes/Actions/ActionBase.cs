using Newtonsoft.Json;

namespace JsonLib.Classes.Actions
{
    #region ActionBase
    public class ActionBase
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Action { get; set; }

    }

    public class ActionWithTime : ActionBase
    {

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int timestamp { get; set; }
    }
    #endregion
}
