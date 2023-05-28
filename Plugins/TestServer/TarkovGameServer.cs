using NetCoreServer;
using System.Net.Sockets;
using System.Net;

namespace TestServer
{
    public class TarkovGameServer : UdpServer
    {
        public TarkovGameServer(IPAddress address, int port) : base(address, port) { }

        protected override void OnStarted()
        {
            Console.WriteLine("TarkovGameServer started!");
            ReceiveAsync();
        }

        protected override void OnReceived(EndPoint endpoint, byte[] buffer, long offset, long size)
        {
            Console.WriteLine($"{endpoint} Sent: {BitConverter.ToString(buffer.Take((int)size).ToArray())}");

            //Sending back :(
            SendAsync(endpoint, buffer, 0, size);
        }

        protected override void OnSent(EndPoint endpoint, long sent)
        {
            ReceiveAsync();
        }

        protected override void OnStopped()
        {
            Console.WriteLine("TarkovGameServer stopped!");
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"UDP server caught an error with code {error}");
        }
    }
}