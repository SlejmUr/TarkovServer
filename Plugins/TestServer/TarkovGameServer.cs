using NetCoreServer;
using ServerLib.Utilities;
using System.Net;
using System.Net.Sockets;

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

            //Sending back :(
            SendAsync(endpoint, buffer, 0, size);
        }

        protected override void OnSent(EndPoint endpoint, long sent)
        {
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