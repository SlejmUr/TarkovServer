using ServerLib.Controllers;
using System.Text;

namespace TestServer.Packets
{
    /// <summary>
    /// 147 PacketId, Sent firstly when connected to Unity Server
    /// </summary>
    public static class OneFourSeven
    {
        /// <summary>
        /// Getting the SessiondID and sending back Location (Needed for the BundeName)
        /// </summary>
        /// <param name="PacketData"></param>
        /// <returns></returns>
        public static (bool IsHandled, byte[] SendData) ProcessPacket(byte[] PacketData)
        {
            byte[] ret = BitConverter.GetBytes(147);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(ret);

            var SessionID = Encoding.Default.GetString(PacketData);

            var match = MatchController.GetMatch(SessionID);
            if (!match.IsNew)
            {
                ret = ret.Concat(Encoding.Default.GetBytes(match.matchData.Location)).ToArray();
            }
            return (true, ret);
        }
    }
}
