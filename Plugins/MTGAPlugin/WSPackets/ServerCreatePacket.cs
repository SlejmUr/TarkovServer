using JsonLib.Classes.Request;

namespace MTGAPlugin.WSPackets
{
    public class ServerCreatePacket : WSBasePacket
    {
        public override string Method { get => "ServerCreate"; }
        public RaidSettings RaidSettings { get; set; }
        public string ServerName { get; set; }
        public bool IsPrivate { get; set; }
        public string JoinCode { get; set; } // generated at server
    }
}
