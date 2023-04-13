using Newtonsoft.Json;

namespace ServerLib.Json.Classes
{
    public class ProfileAddon
    {
        [JsonProperty("Id", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("FriendIds", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FriendIds { get; set; }

        [JsonProperty("Friends", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public FriendList Friends { get; set; }

        [JsonProperty("FriendRequestInbox", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<FriendRequester> FriendRequestInbox { get; set; } = new();

        [JsonProperty("FriendRequestOutbox", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<FriendRequester> FriendRequestOutbox { get; set; } = new();
    }
}
