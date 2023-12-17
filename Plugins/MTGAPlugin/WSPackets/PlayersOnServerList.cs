using Newtonsoft.Json;

namespace MTGAPlugin.WSPackets
{
    public class PlayersOnServerList : WSBasePacket
    {
        public override string Method { get => "PlayerListOnServer"; }

        [JsonProperty("PlayerList")]
        public List<string> PlayerList { get; set; } = new List<string>();
    }
}
