using Newtonsoft.Json;

namespace MTGAPlugin.WSPackets
{
    public class WSBasePacket
    {
        public WSBasePacket() 
        {
            Time = DateTimeOffset.Now.ToUnixTimeMilliseconds() - 1672527600000; //Smaller number!!!
        }

        [JsonProperty("ServerId")]
        public virtual string ServerId { get; set; } = "";

        [JsonProperty("GroupId")]
        public virtual string GroupId { get; set; } = "";

        [JsonProperty("t")]
        public virtual long Time { get; set; } = 0;

        [JsonProperty("Method")]
        public virtual string Method { get; set; } = null;

        [JsonProperty("AccountId")]
        public virtual string AccountId { get; set; } = "";

        [JsonProperty("ProfileId")]
        public virtual string ProfileId { get; set; } = "";
    }
}
