namespace MTGAPlugin.WSPackets
{
    public interface IWSBasePacket
    {
        public string Method { get; set; }
        public string AccountId { get; set; }
        public string ServerId { get; set; }
        public string GroupId { get; set; }
        public long Time { get; }
    }
}
