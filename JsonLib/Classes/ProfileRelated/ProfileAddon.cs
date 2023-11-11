using JsonLib.Classes.Request;
using JsonLib.Classes.Response;
using JsonLib.Enums;
using Newtonsoft.Json;

namespace JsonLib.Classes.ProfileRelated
{
    public class ProfileAddon
    {
        [JsonProperty("Friends", NullValueHandling = NullValueHandling.Ignore)]
        public FriendList Friends { get; set; }

        [JsonProperty("FriendRequestInbox", NullValueHandling = NullValueHandling.Ignore)]
        public List<FriendRequester> FriendRequestInbox { get; set; } = new();

        [JsonProperty("FriendRequestOutbox", NullValueHandling = NullValueHandling.Ignore)]
        public List<FriendRequester> FriendRequestOutbox { get; set; } = new();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EPerms Permission { get; set; } = EPerms.User;
    }
}
