using Newtonsoft.Json;
using ServerLib.Json.Enums;

namespace ServerLib.Json.Classes
{
    public class ProfileAddon
    {
        [JsonProperty("Friends", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public FriendList Friends { get; set; }

        [JsonProperty("FriendRequestInbox", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<FriendRequester> FriendRequestInbox { get; set; } = new();

        [JsonProperty("FriendRequestOutbox", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public List<FriendRequester> FriendRequestOutbox { get; set; } = new();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EPerms Permission { get; set; }
    }
}
