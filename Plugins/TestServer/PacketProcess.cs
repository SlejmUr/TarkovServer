using TestServer.Packets;

namespace TestServer
{
    public static class PacketProcess
    {
        public static byte[] Process(int PacketId, byte[] data)
        {
            byte[] ret = new byte[] { 0x00 };
            switch (PacketId)
            {
                case 147:
                    var packet = OneFourSeven.ProcessPacket(data);
                    if (packet.IsHandled)
                        ret = packet.SendData;
                    break;
                default:
                    break;
            }
            return ret;
        }

    }
}
