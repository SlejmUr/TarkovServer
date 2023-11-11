using JsonLib.Classes.ProfileRelated;
using Newtonsoft.Json;

namespace JsonLib.Classes.Response
{
    public class FriendList
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Character.Base> Friends { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Ignore { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> InIgnoreList { get; set; }
    }
}
