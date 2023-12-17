namespace MTGAPlugin.WSPackets
{
    public class ServerExistsPacket : WSBasePacket
    {
        public override string Method { get => "ServerExists"; }
        public bool ServerStatusOK { get; set; } = false;
    }
}
