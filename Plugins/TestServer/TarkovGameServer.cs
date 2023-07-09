using NetCoreServer;
using System.Net.Sockets;
using System.Net;
using ServerLib.Utilities;

namespace TestServer
{
    public class TarkovGameServer : UdpServer
    {
        public TarkovGameServer(IPAddress address, int port) : base(address, port) { }

        protected override void OnStarted()
        {
            Debug.PrintInfo("TarkovGameServer started!", "TarkovGameServer");
            ReceiveAsync();
        }

        protected override void OnReceived(EndPoint endpoint, byte[] buffer, long offset, long size)
        {
            Debug.PrintInfo($"{endpoint} Sent: {BitConverter.ToString(buffer.Take((int)size).ToArray())}", "TarkovGameServer");
            var buf = buffer.Take((int)size).ToArray();
            var packetId = BitConverter.ToInt32(buf, 0);
            //removing the 4 bytes packetId
            var rsp = PacketProcess.Process(packetId, buf[4..]);
            //Sending to UnityServer
            SendAsync(endpoint, rsp, 0, rsp.Length);
        }

        protected override void OnSent(EndPoint endpoint, long sent)
        {
            Debug.PrintInfo($"{endpoint} Sending Bytes {sent}");
            ReceiveAsync();
        }

        protected override void OnStopped()
        {
            Debug.PrintInfo("TarkovGameServer stopped!", "TarkovGameServer");
        }

        protected override void OnError(SocketError error)
        {
            Debug.PrintError($"UDP server caught an error with code {error}", "TarkovGameServer");
        }
    }
}