using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class FriendSendJson
    {

        [JsonProperty("requestId")]
        public string RequestId;

        [JsonProperty("retryAfter")]
        public int RetryAfter;

        [JsonProperty("status")]
        public int Error;
    }
}
